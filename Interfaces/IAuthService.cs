using System;
using Food_Tracking_API.DTOs;
using Food_Tracking_API.DTOs.Auth;
using Food_Tracking_API.Models;

namespace Food_Tracking_API.Interfaces;

public interface IAuthService
{
    public Task<User> CreateUser(RegisterDTO user);
    public Task<User?> Login(LoginDTO loginDTO);
}
