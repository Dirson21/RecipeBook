using Application.Dto;
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
using Microsoft.AspNetCore.Identity;
using Domain.Repository;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IUserAccountConverter _userConverter;


        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager, IUserAccountConverter userConverter)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _userConverter = userConverter;
        }

        public void login()
        {
            throw new NotImplementedException();
        }

        public Guid Registration(RegistrationFormDto registrationForm)
        {
            if (registrationForm.Password != registrationForm.ConfirmPassword)
            {
                throw new Exception("Пароли не совпадают");
            }
            

            UserAccount user = _userConverter.RegistrationFormToUserAccount(registrationForm);
           
            var result = _userManager.CreateAsync(user, registrationForm.Password).GetAwaiter().GetResult();
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            return user.Id;
        }
    }
}
