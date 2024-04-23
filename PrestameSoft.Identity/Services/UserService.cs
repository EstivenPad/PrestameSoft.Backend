using Microsoft.AspNetCore.Identity;
using PrestameSoft.Application.Contracts.Identity;
using PrestameSoft.Application.Models;
using PrestameSoft.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<MoneyLender> GetMoneyLender(string userId)
        {
            var moneyLender = await _userManager.FindByIdAsync(userId);

            return new MoneyLender
            {
                Id = moneyLender.Id,
                FirstName = moneyLender.Firstname,
                LastName = moneyLender.Lastname,
                Email = moneyLender.Email
            };
        }

        public async Task<List<MoneyLender>> GetMoneyLenders()
        {
            var moneyLenders = await _userManager.GetUsersInRoleAsync("MoneyLender");

            return moneyLenders.Select(q => new MoneyLender
            {
                Id = q.Id,
                FirstName = q.Firstname,
                LastName = q.Lastname,
                Email = q.Email
            }).ToList();
        }
    }
}
