﻿using SportShop.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace SportShop.DAL.Interfaces
{
    public interface IUnitOfWorkIdentity : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
