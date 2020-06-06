using SportShop.DAL.Entities;
using System;


namespace SportShop.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
