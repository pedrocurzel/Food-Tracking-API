using System;

namespace Food_Tracking_API.Interfaces;

public interface IPasswordHasher
{
    public (byte[] hash, byte[] salt) HashPassword(string password);
    public bool Verify(string password, byte[] savedHash, byte[] savedSalt);
}

