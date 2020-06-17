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
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public string Index()
        {
            return "Go to Insert Dummy Role";
        }

        public IActionResult Insert()
        {
            var entity = new Person
            {
                Name = "Baki",
                Surname = "Altun",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _personRepository.Insert(entity);

            return Ok("Başarılı");
        }
    }
}