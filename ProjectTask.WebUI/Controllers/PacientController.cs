using System;
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
            ViewData["Title"] = "Список пациентов";

            return View();
        }

        public PartialViewResult IndexGrid(string search)
        {
            var dtos = Service.GetDTOs();

            if (!string.IsNullOrEmpty(search))
            {
                dtos = dtos.Where(x => x.IIN.Contains(search) || x.SurName.Contains(search));
            }

            return PartialView(nameof(IndexGrid), dtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Создать пациента";

            return View(new PacientViewModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Изменить пациента";

            var dto = Service.GetDTO(id);

            return View(nameof(Create), dto);
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> EditPostAsync(PacientViewModel dto)
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
            ViewData["Title"] = "Удалить из списка пациента";

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