using System;
using System.Text.RegularExpressions;
using AutoMapper;
using Food_Tracking_API.Context;
using Food_Tracking_API.DTOs;
using Food_Tracking_API.DTOs.Auth;
using Food_Tracking_API.Interfaces;
using Food_Tracking_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracking_API.Services;

public class AuthService(IPasswordHasher passwordHasherService, IMapper _mapper, FoodTrackingContext _context) : IAuthService
{
    public async Task<User?> CreateUser(RegisterDTO register)
    {
        var userExists = await _context.Users.FirstOrDefaultAsync(x => x.Email == register.Email);
        if (userExists != null) return null;

        var (hash, salt) = passwordHasherService.HashPassword(register.Password);
        var user = _mapper.Map<User>(register);
        user.PasswordHash = hash;
        user.PasswordSalt = salt;
        var e = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return e.Entity;
    }

    public async Task<User?> Login(LoginDTO loginDTO)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginDTO.Email);

        if (user == null) return null;

        if (!passwordHasherService.Verify(loginDTO.Password, user.PasswordHash, user.PasswordSalt)) return null;

        return user;
    }
}
