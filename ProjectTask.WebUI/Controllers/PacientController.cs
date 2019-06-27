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

            return View(dtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView(nameof(Create), new PacientViewModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dto = Service.GetDTO(id);
            return PartialView(nameof(Edit), dto);
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> EditPostAsync(PacientViewModel dto)
        {
            if (ModelState.IsValid)
            {
                await Service.SaveAsync(dto);

                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Create), dto);
        }


    }
}