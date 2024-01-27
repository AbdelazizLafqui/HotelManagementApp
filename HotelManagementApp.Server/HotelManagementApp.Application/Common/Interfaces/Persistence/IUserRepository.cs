﻿using HotelManagementApp.Domain.Entities;

namespace HotelManagementApp.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);

    }
}