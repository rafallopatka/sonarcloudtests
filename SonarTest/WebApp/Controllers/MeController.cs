﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class MeController : ApiController
    {
        private ApplicationUserManager _userManager;

        public MeController()
        {
        }

        public MeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/Me
        public GetViewModel Get()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return new GetViewModel() { Hometown = user.Hometown };
        }

        public GetViewModel Get(int a)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return new GetViewModel() { Hometown = user.Hometown };
        }

        public GetViewModel Get(string a)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return new GetViewModel() { Hometown = user.Hometown };
        }
    }

    public class Class1
    {
        public decimal Calculate(decimal amount, int type, int years)
        {
            decimal result = 0;
            decimal disc = (years > 5) ? (decimal)5/100 : (decimal)years/100; 
            if (type == 1)
            {
                result = amount;
            }
            else if (type == 2)
            {
                result = (amount - (0.1m * amount)) - disc * (amount - (0.1m * amount));
            }
            else if (type == 3)
            {
                result = (0.7m * amount) - disc * (0.7m * amount);
            }
            else if (type == 4)
            {
                result = (amount - (0.5m * amount)) - disc * (amount - (0.5m * amount));
            }
            return result;
        }
    }
}