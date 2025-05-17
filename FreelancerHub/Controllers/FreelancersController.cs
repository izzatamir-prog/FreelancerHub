using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelancerHub.Conn;
using Microsoft.EntityFrameworkCore;

namespace FreelancerHub.Controllers
{
    public class FreelancersController : Controller
    {
        //private readonly FreelancerDbContext _context;

        public IActionResult Dashboard()
        {
            return View("Dashboard");
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
