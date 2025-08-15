using Food_Tracking_API.Context;
using Food_Tracking_API.DTOs;
using Food_Tracking_API.Interfaces;
using Food_Tracking_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracking_API.Services;

public class DiaryFoodService(FoodTrackingContext _context) : IDiaryFoodService
{
    public async Task<DiaryFood> Create(DiaryFood DiaryFood)
    {
        var e = await _context.DiaryFoods.AddAsync(DiaryFood);
        await _context.SaveChangesAsync();
        return (await Get(e.Entity.Id))!;
    }

    public async Task<List<DiaryFood>> GetByDiaryId(int diaryId)
    {
        return await _context.DiaryFoods
        .Include(x => x.Diary)
        .Include(x => x.Food)
        .Where(x => x.DiaryId == diaryId).ToListAsync() ?? [];
    }

    public async Task<DiaryFood?> Get(int diaryFoodId)
    {
        return await _context.DiaryFoods
        .Include(x => x.Diary)
        .Include(x => x.Food)
        .FirstOrDefaultAsync(
            x => x.Id == diaryFoodId
        );
    }
}