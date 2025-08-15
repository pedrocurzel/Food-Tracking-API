using AutoMapper;
using Food_Tracking_API.DTOs;
using Food_Tracking_API.DTOs.Auth;
using Food_Tracking_API.Interfaces;
using Food_Tracking_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food_Tracking_API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(ILogger<DiaryController> logger, IMapper _mapper, IAuthService _authService, ITokenService tokenService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO register)
    {
        var res = await _authService.CreateUser(register);
        if (res == null) return BadRequest(new
        {
            message = "User already exists",
            error = true
        });
        return Created();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        User? loggedUser = await _authService.Login(loginDTO);
        if (loggedUser == null) return BadRequest(new
        {
            error = true,
            message = "Incorrect Email or Password!"
        });
        return Ok(new
        {
            token = tokenService.GenerateToken(loggedUser),
            userId = loggedUser.Id,
            email = loggedUser.Email
        });
    }

    [Authorize]
    [HttpGet("validate-token")]
    public IActionResult ValidateToken()
    {
        return Ok(new {error = false});
    }
}