﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTask.Services;
using ProjectTask.ViewModels;
using ProjectTask.WebUI.Controllers.Abstract;

namespace ProjectTask.WebUI.Controllers
{
    public class PacientController : ServicedController<PacientService>
    {
        public PacientController(PacientService service) : base(service)
        {
        }

        public IActionResult Index()
        {
            var dtos = Service.GetDTOs();

            ViewData["Title"] = "Список пациентов";

            return View(dtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Создать пациента";

            return PartialView(nameof(Create), new PacientViewModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Изменить пациента";

            var dto = Service.GetDTO(id);

            return PartialView(nameof(Create), dto);
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> EditPostAsync(PacientViewModel dto)
        {
            if (ModelState.IsValid)
            {
                await Service.SaveAsync(dto);
            }

            return PartialView(nameof(Create), dto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Удалить из списка пациента";

            var dto = Service.GetDTO(id);

            return PartialView(nameof(Delete), dto);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(PacientViewModel dto)
        {
            ViewData["Title"] = "Удалить из списка";

            await Service.DeleteAsync(dto.Id);
            
            return PartialView(nameof(Delete), dto);
        }
    }
}