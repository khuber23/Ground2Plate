﻿using Ground2Plate.Models;

namespace Ground2Plate.Maui.Services.Login
{
    public interface ILoginService
    {
        Task<User> Login(string email, string password);

        //void Register(User user);

    }
}