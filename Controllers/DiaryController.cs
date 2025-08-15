using AutoMapper;
using Food_Tracking_API.Context;
using Food_Tracking_API.DTOs;
using Food_Tracking_API.Interfaces;
using Food_Tracking_API.Models;
using Food_Tracking_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracking_API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class DiaryController(
    FoodTrackingContext _context,
    ILogger<DiaryController> _logger,
    IDiaryService _diaryService,
    IMapper _mapper
)
    : ControllerBase
{
    [HttpGet("get/{userId}/{day}/{month}/{year}")]
    public async Task<IActionResult> GetDiaryByDate(int userId, int day, int month, int year)
    {
        Diary? diary = await _diaryService.GetDiaryByDate(userId: userId, date: new DateTime(day: day, month: month, year: year));
        if (diary == null) return NotFound();
        return Ok(_mapper.Map<DiaryDTO>(diary));
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateDiaryByDate([FromBody] CreateDiaryDTO createDiary)
    {
        Diary? diary = await _diaryService.GetDiaryByDate(userId: createDiary.UserId, date: new DateTime(day: createDiary.Date.Day, month: createDiary.Date.Month,
        year: createDiary.Date.Year));
        if (diary != null) return Conflict("Diary Already Exists!");
        diary = await _diaryService.CreateDiaryByDate(createDiary);
        return CreatedAtAction(
            nameof(GetDiaryByDate),
            new {
                userId = createDiary.UserId,
                day = diary.Date.Day,
                month = diary.Date.Month,
                year = diary.Date.Year
            },
            _mapper.Map<DiaryDTO>(diary)
        );
    }
}
