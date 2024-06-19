using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUD_Students_POO2.Models; // Asegúrate de que este espacio de nombres sea correcto
using System;
using System.Collections.Generic;
using System.Linq;
using CRUD_Students_POO2.Entities;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Students_POO2.Controllers
{
    public class DoctoresController : Controller
    {
        private readonly ILogger<DoctoresController> _logger;
        private readonly ApplicationDbContext _context;

        public DoctoresController(ApplicationDbContext context, ILogger<DoctoresController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult DoctoresAdd()
        {
            return View();
        }

            [HttpPost]
        public IActionResult DoctoresAdd(DoctoresModel model)
        {
            if (!ModelState.IsValid)
            {
            // Manejar el caso donde el modelo no es válido
            return View(model);
            }

            // Crear el objeto Doctores y asignar los valores del modelo
            Doctores nuevoDoctor = new Doctores()
            {
                Id = Guid.NewGuid(), // Generar un nuevo GUID para el ID del doctor
                Name = model.Name,
                LastName = model.LastName,
                Age = model.Age,
                specialism = model.specialism,
                Tel = model.Tel,
                Cel = model.Cel,
                address = model.address
            };

            // Agregar el nuevo doctor al contexto y guardar los cambios en la base de datos
            _context.Doctores.Add(nuevoDoctor);
             _context.SaveChanges();

            // Redirigir a la acción DoctorList para mostrar la lista actualizada
            return RedirectToAction("DoctorList");
        }


        public IActionResult DoctorList()
        {
            //PARA CARGAR INFO = SELECT
            List<DoctoresModel> list = 
            _context.Doctores.Select(static d => new DoctoresModel
            
            {
                Id = d.Id,
                Name = d.Name,
                LastName = d.LastName,
                Age = d.Age,
                specialism = d.specialism,
                Tel = d.Tel,
                Cel = d.Cel,
                address = d.address            
            }).ToList();

            _logger.LogInformation("Cargando lista de doctores");

            return View(list);
            
        }

        [HttpGet]
        public IActionResult DoctoresDeleted(int Id)
        {
            Doctores doctor = this._context.Doctores.Where(d => d.Id = Id).First();

            if (doctor == null)
            {
                return RedirectToAction("DoctoresList","Doctores");

            }

            Doctores doctores = new Doctores()
                Id = d.Id,
                Name = d.Name,
                LastName = d.LastName,
                Age = d.Age,
                specialism = d.specialism,
                Tel = d.Tel,
                Cel = d.Cel,
                address = d.address

            return View (doctores);
        }

        [HttpPost]
        public IActionResult DoctoresDeleted(DoctoresModel doctoresModel)
        {
            bool exists = this._context.Doctores.Any(a => a.Id == doctoresModel.Id);
            if (!exists)
            {
                return View (doctoresModel);
            }

            Doctores doctores = this._context.Doctores.Where (d => d.Id == doctoresModel.Id).First();
            doctores.Id=doctores.Id;
            doctores.Name=doctores.Name;
            doctores.LastName=doctores.LastName;
            doctores.Age=doctores.Age;
            doctores.specialism = doctores.specialism;
            doctores.Tel=doctores.Tel;
            doctores.Cel=doctores.Cel;
            doctores.address=doctores.address;

            this._context.Doctores.Remove(doctores);
            this._context.SaveChanges();

            return RedirectToAction("DoctoresList","Doctores");

            
        }
    
    [HttpGet]
    public IActionResult DoctoresEdit(int Id)
    {
            Doctores doctor = this._context.Doctores.Where(d => d.Id = Id).First();

            if (doctor==null)
            {
                return RedirectToAction("DoctoresList","Doctores");
            }

            DoctoresModel model = new DoctoresModel();
            model.Id = doctor.Id;
            model.Name = doctor.Name;
            model.LastName = doctor.LastName;
            model.Age = doctor.Age;
            model.specialism = doctor.specialism;
            model.Tel = doctor.Tel;
            model.Cel = doctor.Cel;
            model.address = doctor.address;

            return View(model);
        
    }

     [HttpPost]
     public IActionResult DoctoresEdit(DoctoresModel doctoresModel)
     {
        Doctores doctores1 = this._context.Doctores
        .Where(d => d.Id == doctoresModel.Id).First();

        if(doctoresModel == null)
        {
            return RedirectToAction("VehiculosModel");
        }
        doctores1.Name = doctoresModel.Name;
        doctores1.LastName = doctoresModel.LastName;
        doctores1.Age = doctoresModel.Age;
        doctores1.specialism = doctoresModel.specialism;
        doctores1.Tel = doctoresModel.Tel;
        doctores1.Cel = doctoresModel.Cel;
        doctores1.address = doctoresModel.address;


        this._context.Doctores.Update(doctores1);
        this._context.SaveChanges();
       
       return RedirectToAction("VehiculosList","Vehiculos");
     }
    }
}