using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;

namespace Presentation.Web.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public string Index()
        {
            return "Go to Insert Dummy Role";
        }

        public IActionResult Insert()
        {
            var role = new Role
            {
                Name = "Admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _roleRepository.Insert(role);

            return Ok("Başarılı");
        }
    }
}