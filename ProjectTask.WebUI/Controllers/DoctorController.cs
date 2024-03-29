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
    public class DoctorController : ServicedController<DoctorService>
    {
        public DoctorTypeService DoctorTypeService { get; }

        public DoctorController(DoctorService service
            , DoctorTypeService doctorTypeService) : base(service)
        {
            DoctorTypeService = doctorTypeService;
        }

        public IActionResult Index()
        {
            var dtos = Service.GetDTOs();

            ViewData["Title"] = "Список врачей";

            return View(dtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Добавление в список";
            ViewData["types"] = DoctorTypeService.GetDTOs();
            return View(new DoctorViewModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Редактирование";
            ViewData["types"] = DoctorTypeService.GetDTOs();
            var dto = Service.GetDTO(id);

            return View(nameof(Create), dto);
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> EditPost(DoctorViewModel dto)
        {
            if (ModelState.IsValid)
            {
                await Service.SaveAsync(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewData["Title"] = "Удалить из списка";

            var dto = Service.GetDTO(id);

            return View(dto);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await Service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}