﻿using System.Collections;
using Application.DAOInterfaces;
using Domain;

namespace FileData.DAOs;

public class UserFileDao:IUserDAO
{

    private readonly FileContext fileContext;

    public UserFileDao(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }

    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (fileContext.Users.Any())
        {
            userId = fileContext.Users.Max(u => u.id);
            userId++;
        }

        user.id = userId;

        fileContext.Users.Add(user);
        fileContext.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User> GetUserByUsernameandPassword(string userName, string password)
    {
        User? existing = fileContext.Users.FirstOrDefault(u =>
            u.username.Equals(userName, StringComparison.OrdinalIgnoreCase)& u.password.Equals(password)
        );
        return Task.FromResult(existing);
    }
    
    

    public Task<User?> GetUserById(int OwnerId)
    {
        User? existing = fileContext.Users.FirstOrDefault(u => u.id == OwnerId);
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<User?>> GetAllUsersAsync()
    {
        IEnumerable<User?> users = fileContext.Users.AsEnumerable();
        return Task.FromResult(users);
    }
}