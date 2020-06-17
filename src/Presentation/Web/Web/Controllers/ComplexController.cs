using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces.Data.Library;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;

namespace Presentation.Web.Web.Controllers
{
    public class ComplexController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;
        private readonly IRoleRepository _roleRepository;

        public ComplexController(IUnitOfWork unitOfWork, IPersonRepository personRepository, IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _roleRepository = roleRepository;
        }

        public string Index()
        {
            return "Welcome";
        }

        public IActionResult ComplexSuccessfulInsert()
        {
            var entity = new Person
            {
                Name = "Baki",
                Surname = "Altun",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };


            var role = new Role
            {
                Name = "Admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _unitOfWork.Begin();
            _roleRepository.Insert(role);
            _personRepository.Insert(entity);
            _unitOfWork.Commit();

            return Ok("Başarılı bir şekilde eklendi.");
        }

        public IActionResult ComplexFailedInsert()
        {
            var person = new Person
            {
                Name = "Baki",
                Surname = "Altun",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };


            var role = new Role
            {
                Name = "Admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            try
            {
                _unitOfWork.Begin();
                _roleRepository.Insert(role);
                throw new Exception("Somethings are wrong");
                _personRepository.Insert(person);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
            }

            return Ok("Hata oluştu. İşlemler geri alındı.");
        }
    }
}