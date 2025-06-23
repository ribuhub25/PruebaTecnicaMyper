using PruebaTecnicaMyper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMyper.DAL.Repositories
{
    public interface IUbigeoRepository
    {
        Task<List<ResponseSelect>> GetDepartamentosAsync();
        Task<List<ResponseSelect>> GetProvinciasAsync(int departamentoId);
        Task<List<ResponseSelect>> GetDistritosAsync(int provinciaId);
    }
    public class ResponseSelect
    {
        public string? Text { get; set; }
        public int Value { get; set; }
    }
}
