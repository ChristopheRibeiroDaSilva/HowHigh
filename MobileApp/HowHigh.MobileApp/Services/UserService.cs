using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowHigh.MobileApp.Services
{
    public class UserService : IUserService
    {
        public Task<HttpResponseMessage> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
