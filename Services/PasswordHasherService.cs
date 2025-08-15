using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Food_Tracking_API.Services;

using System.Security.Cryptography;
using Food_Tracking_API.Interfaces;
using Microsoft.AspNetCore.Identity;

public class PasswordHasherService : IPasswordHasher
{
    private const int SaltSize = 16; // 128-bit
    private const int KeySize = 32;  // 256-bit
    private const int Iterations = 100_000; // recommended >= 100,000

    public (byte[] hash, byte[] salt) HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(KeySize);
        return (hash, salt);
    }

    public bool Verify(string password, byte[] savedHash, byte[] savedSalt)
    {
        var pbkdf2 = new Rfc2898DeriveBytes(password, savedSalt, Iterations, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(KeySize);
        return CryptographicOperations.FixedTimeEquals(hash, savedHash);
    }
}
