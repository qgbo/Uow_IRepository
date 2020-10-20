using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestUOW.Data;

namespace TestUOW
{
    public class MySampleActionFilterAttribute : Attribute,IActionFilter
    {
        TestUOWContext _dbcontext;
        public MySampleActionFilterAttribute(TestUOWContext context)
        {
            _dbcontext = context;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
           
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
            _dbcontext.SaveChanges();
        }
    }
}
