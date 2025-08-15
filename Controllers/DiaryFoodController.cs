using AutoMapper;
using Food_Tracking_API.Context;
using Food_Tracking_API.DTOs;
using Food_Tracking_API.Interfaces;
using Food_Tracking_API.Models;
using Food_Tracking_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food_Tracking_API.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class DiaryFoodController(IMapper _mapper, IDiaryFoodService _diaryFoodService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateDiaryFood([FromBody] DiaryFoodDTO createDiaryFood)
    {
        DiaryFood diaryFood = _mapper.Map<DiaryFood>(createDiaryFood);
        return Ok(
            _mapper.Map<DiaryFoodDTO>(
                await _diaryFoodService.Create(diaryFood)
            )
        );
    }

    [HttpGet("get-by-diary/{DiaryId}")]
    public async Task<IActionResult> GetDiaryFoodByDiaryId(int DiaryId)
    {
        return Ok(
            _mapper.Map<List<DiaryFoodDTO>>(await _diaryFoodService.GetByDiaryId(DiaryId))
        );
    }

    [HttpGet("get/{DiaryFoodId}")]
    public async Task<IActionResult> GetDiaryFoodById(int DiaryFoodId)
    {
        var df = await _diaryFoodService.Get(DiaryFoodId);
        if (df == null) return NotFound();
        return Ok(
            _mapper.Map<DiaryFoodDTO>(df)
        );
    }
}