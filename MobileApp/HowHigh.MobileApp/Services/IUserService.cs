using HowHigh.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowHigh.MobileApp.Services
{
    public interface IUserService
    {
        Task<HttpResponseMessage> Login(string username, string password);
    }
}
