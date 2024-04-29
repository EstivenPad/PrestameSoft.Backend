using PrestameSoft.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<MoneyLender>> GetMoneyLenders();
        Task<MoneyLender> GetMoneyLender(string userId);
    }
}
