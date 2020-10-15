using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_T2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen_T2.Controllers
{
    public class BaseController : Controller
    {
        private readonly ContexPokemon context;
        public BaseController(ContexPokemon context)
        {
            this.context = context;
        }

        protected User LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = context.Users.Where(o => o.Username == claim.Value).FirstOrDefault();
            
            return user;
        }
    }
}
