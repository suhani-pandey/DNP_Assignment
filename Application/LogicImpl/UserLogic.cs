﻿using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain;

namespace Application.LogicImpl;

public class UserLogic:IUserLogic
{
    private readonly IUserDAO UserDao;

    public UserLogic(IUserDAO userDao)
    {
        UserDao = userDao;
    }

    public async Task<User> CreateAsync(User userToCreate)
    {
        User? existingUser = await UserDao.GetUserByUsernameandPassword(userToCreate.username,userToCreate.password,userToCreate.rePassword);
        if (existingUser!= null)
        {
            throw new Exception("Username already exists");
        }

        ValidateData(userToCreate);
        User toCreate = new User
        {
            username = userToCreate.username,
            password= userToCreate.password,
            rePassword=userToCreate.rePassword
        };
        User created = await UserDao.CreateAsync(toCreate);
        return created;
    }
    
    private static void ValidateData(User userToCreate)
    {
        string userName = userToCreate.username;
        string password = userToCreate.password;
        string rePassword = userToCreate.rePassword;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");

        if (password.Length>8 || password.Length<4)
            throw new Exception("Password must be of 8 characters");
        
        if(!(rePassword.Equals(password)))
        {
            throw new Exception("Password doesnt match");
        }
    }
}