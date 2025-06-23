using PruebaTecnicaMyper.DAL.Repositories;
using PruebaTecnicaMyper.Domain.DTOs;
using PruebaTecnicaMyper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMyper.BLL.Services
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly ITrabajadorRepository _trabajadorRepository;

        public TrabajadorService(ITrabajadorRepository trabajadorRepository)
        {
            _trabajadorRepository = trabajadorRepository;
        }
        public async Task<ReturnResponse<bool>> Add(TrabajadorDTO trabajadorDTO)
        {
            var trabajador = new Trabajador
            {
                IdDepartamento = trabajadorDTO.IdDepartamento,
                IdDistrito = trabajadorDTO.IdDistrito,
                IdProvincia = trabajadorDTO.IdProvincia,
                Nombres = trabajadorDTO.Nombres,
                NumeroDocumento = trabajadorDTO.NumeroDocumento,
                Sexo = trabajadorDTO.Sexo,
                TipoDocumento = trabajadorDTO.TipoDocumento
            };
            return await _trabajadorRepository.Add(trabajador);
        }

        public async Task<ReturnResponse<bool>> Delete(int id)
        {
            return await _trabajadorRepository.Delete(id);
        }

        public async Task<ReturnResponse<List<pMAINGET_TrabajadoresSelect>>> GetAll(string filter)
        {
            var response = await _trabajadorRepository.GetAll(filter);

            return response;
        }

        public async Task<ReturnResponse<TrabajadorDTO>> GetById(int id)
        {
            var response = await _trabajadorRepository.GetById(id);
            Trabajador? trabajador = response.Data;
            var trabajadorDTO = new TrabajadorDTO
            {
                Id = id,
                IdDepartamento = trabajador?.IdDepartamento,
                IdDistrito = trabajador?.IdDistrito,
                IdProvincia = trabajador?.IdProvincia,
                Nombres = trabajador?.Nombres,
                NumeroDocumento = trabajador?.NumeroDocumento,
                Sexo = trabajador?.Sexo,
                TipoDocumento = trabajador?.TipoDocumento
            };
            return new ReturnResponse<TrabajadorDTO> { Data = trabajadorDTO, Success = true, Message = response.Message };
        }

        public async Task<ReturnResponse<bool>> Update(TrabajadorDTO trabajadorDTO)
        {
            var trabajador = new Trabajador
            {
                Id = trabajadorDTO.Id,
                IdDepartamento = trabajadorDTO.IdDepartamento,
                IdDistrito = trabajadorDTO.IdDistrito,
                IdProvincia = trabajadorDTO.IdProvincia,
                Nombres = trabajadorDTO.Nombres,
                NumeroDocumento = trabajadorDTO.NumeroDocumento,
                Sexo = trabajadorDTO.Sexo,
                TipoDocumento = trabajadorDTO.TipoDocumento
            };
            return await _trabajadorRepository.Update(trabajador);
        }
    }
}
