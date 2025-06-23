using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaMyper.BLL.Services;
using PruebaTecnicaMyper.DAL.Repositories;
using PruebaTecnicaMyper.UI.ViewModels;
using PruebaTecnicaMyper.UI.Models;
using System.Diagnostics;
using PruebaTecnicaMyper.Domain.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaTecnicaMyper.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITrabajadorService _trabajadorService;
        private readonly IUbigeoRepository _ubigeoRepository;

        public HomeController(ITrabajadorService trabajadorService, IUbigeoRepository ubigeoRepository)
        {
            _trabajadorService = trabajadorService;
            _ubigeoRepository = ubigeoRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearTrabajador(TrabajadorViewModel trabajador)
        {
            ReturnResponse<bool> response = new();
            if (!ModelState.IsValid)
            {
                Dictionary<string, List<string>> errores = ModelState
                .Where(m => m.Value!.Errors.Any())
                .ToDictionary(
                    m => m.Key,
                    m => m.Value!.Errors.Select(e => e.ErrorMessage).ToList()
                 );

                response = new ReturnResponse<bool>
                {
                    Success = false,
                    Message = "Error de validación",
                    Errors = errores
                };
            }
            else
            {
                TrabajadorDTO trabajadorDTO = new()
                {
                    Id = trabajador.Id,
                    IdDepartamento = trabajador.IdDepartamento,
                    IdDistrito = trabajador.IdDistrito,
                    IdProvincia = trabajador.IdProvincia,
                    Nombres = trabajador.Nombres,
                    NumeroDocumento = trabajador.NumeroDocumento,
                    Sexo = trabajador.Sexo,
                    TipoDocumento = trabajador.TipoDocumento
                };
                response = await _trabajadorService.Add(trabajadorDTO);
            }
            return new JsonResult(response);
        }
        [HttpPut]
        public async Task<IActionResult> ModificarTrabajador(TrabajadorViewModel trabajador)
        {
            ReturnResponse<bool> response = new();
            if (!ModelState.IsValid)
            {
                Dictionary<string, List<string>> errores = ModelState
                .Where(m => m.Value!.Errors.Any())
                .ToDictionary(
                    m => m.Key,
                    m => m.Value!.Errors.Select(e => e.ErrorMessage).ToList()
                 );

                response = new ReturnResponse<bool>
                {
                    Success = false,
                    Message = "Error en la validación de datos",
                    Errors = errores
                };
            }
            else
            {
                TrabajadorDTO trabajadorDTO = new()
                {
                    Id = trabajador.Id,
                    IdDepartamento = trabajador.IdDepartamento,
                    IdDistrito = trabajador.IdDistrito,
                    IdProvincia = trabajador.IdProvincia,
                    Nombres = trabajador.Nombres,
                    NumeroDocumento = trabajador.NumeroDocumento,
                    Sexo = trabajador.Sexo,
                    TipoDocumento = trabajador.TipoDocumento
                };
                response = await _trabajadorService.Update(trabajadorDTO);
            }
            return new JsonResult(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetTrabajador(int id)
        {
            var rm = await _trabajadorService.GetById(id);
            var viewModel = new TrabajadorViewModel
            {
                Id = rm.Data!.Id,
                Nombres = rm.Data.Nombres,
                Sexo = rm.Data.Sexo,
                TipoDocumento = rm.Data.TipoDocumento,
                NumeroDocumento = rm.Data.NumeroDocumento,
                IdProvincia = rm.Data.IdProvincia,
                IdDistrito = rm.Data.IdDistrito,
                IdDepartamento = rm.Data.IdDepartamento,
            };
            List<ResponseSelect> departamentos = await _ubigeoRepository.GetDepartamentosAsync();
            ViewBag.Departamentos = new SelectList(departamentos, "Value", "Text");
            return PartialView("_ModalTrabajador", viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetTrabajadores(string filter = "")
        {
            var trabajadores = await _trabajadorService.GetAll(filter);
            return new JsonResult(trabajadores.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetProvincias(int departamentoId)
        {
            var data = await _ubigeoRepository.GetProvinciasAsync(departamentoId);
            var rm = new ReturnResponse<List<ResponseSelect>> { Success = true, Data = data };
            return new JsonResult(rm);
        }
        [HttpGet]
        public async Task<IActionResult> GetDistritos(int provinciaId)
        {
            var data = await _ubigeoRepository.GetDistritosAsync(provinciaId);
            var rm = new ReturnResponse<List<ResponseSelect>> { Success = true, Data = data };
            return new JsonResult(rm);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTrabajador(int id)
        {
            var rm = await _trabajadorService.Delete(id);
            return new JsonResult(rm);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
