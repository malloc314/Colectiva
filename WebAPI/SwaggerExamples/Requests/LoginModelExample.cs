using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests
{
    public class LoginModelExample : IExamplesProvider<LoginModel>
    {
        public LoginModel GetExamples()
        {
            return new LoginModel()
            {
                Username = "username3",
                Password = "Password_3"
            };
        }
    }
}
