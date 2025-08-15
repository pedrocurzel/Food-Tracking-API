using System;
using Food_Tracking_API.DTOs;
using Food_Tracking_API.Models;

namespace Food_Tracking_API.Interfaces;

public interface IDiaryService
{
    Task<Diary?> GetDiaryByDate(int userId, DateTime date);
    Task<Diary> CreateDiaryByDate(CreateDiaryDTO createDiary);
}
