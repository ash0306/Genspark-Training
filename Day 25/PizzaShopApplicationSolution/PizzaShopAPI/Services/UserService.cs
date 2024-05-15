﻿using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models.DTOs;
using PizzaShopAPI.Models;
using System.Security.Cryptography;
using System.Text;
using PizzaShopAPI.Exceptions;
using System.Collections;
using PizzaShopAPI.Services;

namespace PizzaShop.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _repository;

        public UserService(IRepository<int, User> repository)
        {
            _repository = repository;
        }
        public async Task<UserLoginDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _repository.Get(loginDTO.Id);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }

            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                loginDTO.Password = Encoding.UTF8.GetString(userDB.Password);
                return loginDTO;
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<UserRegisterDTO> Register(UserRegisterDTO regiserDTO)
        {
            User user = null;
            try
            {
                user = MapRegiserDTOToUser(regiserDTO);
                user = await _repository.Add(user);
                if (user == null)
                {
                    throw new UnableToRegisterException("Not able to register at this moment");
                }
                regiserDTO.Password = Encoding.UTF8.GetString(user.Password);
                return regiserDTO;
            }
            catch (Exception ex)
            {
                throw new UnableToRegisterException($"Not able to register at this moment : {ex.Message}");
            }

        }

        private User MapRegiserDTOToUser(UserRegisterDTO regiserDTO)
        {
            User user = new User();
            user.Name = regiserDTO.Name;
            user.Email = regiserDTO.Email;
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(regiserDTO.Password));
            return user;
        }
    }
}