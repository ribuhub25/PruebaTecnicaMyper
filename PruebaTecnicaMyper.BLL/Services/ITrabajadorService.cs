using PruebaTecnicaMyper.DAL.Repositories;
using PruebaTecnicaMyper.Domain.DTOs;
using PruebaTecnicaMyper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMyper.BLL.Services
{
    public interface ITrabajadorService
    {
        Task<ReturnResponse<bool>> Add(TrabajadorDTO trabajador);
        Task<ReturnResponse<bool>> Update(TrabajadorDTO trabajador);
        Task<ReturnResponse<bool>> Delete(int id);
        Task<ReturnResponse<TrabajadorDTO>> GetById(int id);
        Task<ReturnResponse<List<pMAINGET_TrabajadoresSelect>>> GetAll(string filter);
    }
}
