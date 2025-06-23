using PruebaTecnicaMyper.Domain.DTOs;
using PruebaTecnicaMyper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMyper.DAL.Repositories
{
    public interface ITrabajadorRepository : IGenericRepository<Trabajador>
    {
        Task<ReturnResponse<List<pMAINGET_TrabajadoresSelect>>> GetAll(string filter);
    }
}
