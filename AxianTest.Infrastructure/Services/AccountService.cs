using AxianTast.Core.Context;
using AxianTast.Core.Entities;
using AxianTest.Infrastructure.Interfaces;
using AxianTest.Infrastructure.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AxianTest.Infrastructure.Services
{
    public class AccountService : IAccount
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public AccountService(ApplicationDBContext dbContext, IConfiguration Configuration)
        {
            _configuration = Configuration;
            _dbContext = dbContext;
        }
        public UserModel Authentication(UserModel userRequest)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(x => x.Email == userRequest.Email);            

            //TODO login Atuh
            if (dbUser == null)
            {
                return new UserModel()
                {
                    Email = "",
                    Type = "",
                    userToken = ""
                };
                
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,dbUser.Email),
                new Claim("UserType",dbUser.Type),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var authLoginKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:validIsser"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authLoginKey, SecurityAlgorithms.HmacSha256Signature)
                );
           

            var usermodel = new UserModel() 
            { 
                Email = dbUser.Email,
                Type = dbUser.Type,
                userToken = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return usermodel;
        }


        private bool IsLoggedIn(UserModel user, User dbUser)
        {
            return dbUser.Email == user.Email && dbUser.Password == user.Password;
        }


    }


    
}
