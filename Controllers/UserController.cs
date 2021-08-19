using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;


namespace Proyecto.Controllers
{
    public class UserController : Controller
    {
        private readonly IServiceUser serviceUser;

        public UserController (ISwerviceUser serviceUser)
        {
            _serviceUser = serviceUser;
        }
    }
}

