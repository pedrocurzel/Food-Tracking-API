using AutoMapper;
using Food_Tracking_API.DTOs;
using Food_Tracking_API.Models;

public class FoodTrackingProfile : Profile
{
    public FoodTrackingProfile()
    {
        CreateMap<Diary, DiaryDTO>().ReverseMap();
        CreateMap<DiaryFood, DiaryFoodDTO>().ReverseMap();
        CreateMap<Food, FoodDTO>().ReverseMap();
        CreateMap<User, RegisterDTO>().ReverseMap();
    }
}