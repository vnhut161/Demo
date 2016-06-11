using System;

namespace MyUp.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        EntitiesDbContext Init();
    }
}