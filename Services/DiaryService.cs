using Food_Tracking_API.Context;
using Food_Tracking_API.DTOs;
using Food_Tracking_API.Interfaces;
using Food_Tracking_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracking_API.Services;

public class DiaryService(FoodTrackingContext _context) : IDiaryService
{
    public async Task<Diary?> GetDiaryByDate(int userId, DateTime date)
    {
        return await _context.Diaries.FirstOrDefaultAsync(
            x => x.UserId == userId &&
                 x.Date.Day ==   date.Day &&
                 x.Date.Month == date.Month &&
                 x.Date.Year ==  date.Year
        );
    }

    public async Task<Diary> CreateDiaryByDate(CreateDiaryDTO createDiary)
    {
        var e = await _context.Diaries.AddAsync(new Diary
        {
            UserId = createDiary.UserId,
            Date = createDiary.Date
        });
        await _context.SaveChangesAsync();
        return e.Entity;
    }
}