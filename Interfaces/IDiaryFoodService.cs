using System;
using Food_Tracking_API.Models;

namespace Food_Tracking_API.Interfaces;

public interface IDiaryFoodService
{
    Task<DiaryFood> Create(DiaryFood DiaryFood);
    Task<List<DiaryFood>> GetByDiaryId(int diaryId);
    Task<DiaryFood?> Get(int diaryFoodId);
}
