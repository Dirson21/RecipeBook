﻿using Application.Dto;
using Application.Converters;
using Domain;
using Domain.UoW;
using Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, UserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public UserDto Login(string login, string password)
        {
            User user = _userRepository.GetByLogin(login);
            if (user == null)
            {
                throw new Exception("Неверный логин");
            }
            if (user.Password != password)
            {
                throw new Exception("Неверный пароль");
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

           

            throw new NotImplementedException();
        }

        public UserDto Logout()
        {
            throw new NotImplementedException();
        }

        public string Registration(UserDto userDto)
        {
            User checkUser = _userRepository.GetByLogin(userDto.Login);
            if (checkUser != null)
            {
                throw new Exception("Данный пользователь уже существует");
            }

            User user = _userRepository.Create(userDto.ConvertToIngridient());

            _unitOfWork.Commit();

            return user.Id.ToString();

        }
    }
}