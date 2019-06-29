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
    public class VisitController : ServicedController<VisitService>
    {
        private DoctorService DoctorService { get; }
        private PacientService PacientService { get; }
        public DoctorTypeService DoctorTypeService { get; }

        public VisitController(VisitService service
            , DoctorService doctorService
            , PacientService pacientService
            , DoctorTypeService doctorTypeService) : base(service)
        {
            DoctorService = doctorService;
            PacientService = pacientService;
            DoctorTypeService = doctorTypeService;
        }


        public IActionResult Index()
        {
            var dtos = Service.GetDTOs();

            ViewData["Title"] = "Список карт посещений";
            ViewData["doctors"] = DoctorService.GetDTOs();
            ViewData["doctor_types"] = DoctorTypeService.GetDTOs();
            ViewData["pacients"] = PacientService.GetDTOs();

            return View(dtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["doctors"] = DoctorService.GetDTOs();
            ViewData["pacients"] = PacientService.GetDTOs();
            ViewData["doctor_types"] = DoctorTypeService.GetDTOs();
            ViewData["Title"] = "Создать карточку";

            return PartialView(nameof(Create), new VisitViewModel() { VisitDate = DateTime.Now});
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dto = Service.GetDTO(id);
            ViewData["doctors"] = DoctorService.GetDTOs();
            ViewData["pacients"] = PacientService.GetDTOs();
            ViewData["doctor_types"] = DoctorTypeService.GetDTOs();
            ViewData["Title"] = "Редактировать карточку";

            return PartialView(nameof(Create), dto);
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> EditPost(VisitViewModel dto)
        {
            if (ModelState.IsValid)
            {
                await Service.SaveAsync(dto);
            }
            ViewData["doctors"] = DoctorService.GetDTOs();
            ViewData["pacients"] = PacientService.GetDTOs();
            ViewData["doctor_types"] = DoctorTypeService.GetDTOs();
            ViewData["Title"] = dto.Id > 0 ? "Редактировать карточку" : "Создать карточку";

            return PartialView(nameof(Create), dto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dto = Service.GetDTO(id);

            ViewData["Title"] = "Удалить карточку";

            return PartialView(dto);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await Service.DeleteAsync(id);

            return PartialView(nameof(Delete));
        }
    }
}