using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Wrappers;

namespace WebAPI.Attributes
{
    public class ValidateFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);

                context.Result = new BadRequestObjectResult(new Response<bool>
                {
                    Succeeded = false,
                    Message = "Something went wrong",
                    Errors = errors
                });
            }
        }
    }
}
