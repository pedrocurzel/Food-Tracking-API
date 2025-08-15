using Food_Tracking_API.Models;

public interface ITokenService
{
    public string GenerateToken(User user);
}