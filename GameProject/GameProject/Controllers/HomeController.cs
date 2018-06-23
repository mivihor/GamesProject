using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Z_DataAccessLayer.Entities;
using Z_DataAccessLayer.Repositories;
using Z_DataAccessLayer.Migrations;
using Z_DataAccessLayer.Interfaces;
using Z_DataAccessLayer.EntitiFramework;

namespace GameProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}