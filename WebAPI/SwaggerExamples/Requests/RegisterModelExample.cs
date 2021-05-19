using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.SwaggerExamples.Requests
{
    public class RegisterModelExample : IExamplesProvider<RegisterModel>
    {
        public RegisterModel GetExamples()
        {
            return new RegisterModel()
            {
                Username = "Your unique username",
                Email = "user@example.com",
                Password = "Your password"
            };
        }
    }
}
