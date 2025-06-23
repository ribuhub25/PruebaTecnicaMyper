using Microsoft.EntityFrameworkCore;
using PruebaTecnicaMyper.DAL.DataContext;
using PruebaTecnicaMyper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMyper.DAL.Repositories
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly MyperContext _context;
        public UbigeoRepository(MyperContext context)
        {
            _context = context;
        }
        public async Task<List<ResponseSelect>> GetDepartamentosAsync()
        {
            List<ResponseSelect> response = new();
            var departamentos = await _context.Departamentos.ToListAsync();
            foreach(var dto in departamentos)
            {
                response.Add(new ResponseSelect() { Text = dto.NombreDepartamento, Value = dto.Id });
            }
            return response;
        }
        public async Task<List<ResponseSelect>> GetDistritosAsync(int provinciaId)
        {
            List<ResponseSelect> response = new();
            List<Distrito> distritos = await _context.Distritos.Where(d=>d.IdProvincia == provinciaId).ToListAsync();
            foreach (var di in distritos)
            {
                response.Add(new ResponseSelect() { Text = di.NombreDistrito, Value = di.Id });
            }
            return response;
        }
        public async Task<List<ResponseSelect>> GetProvinciasAsync(int departamentoId)
        {
            List<ResponseSelect> response = new();
            List<Provincia> provincias = await _context.Provincia.Where(p => p.IdDepartamento == departamentoId).ToListAsync();
            foreach (var pv in provincias)
            {
                response.Add(new ResponseSelect() { Text = pv.NombreProvincia, Value = pv.Id });
            }
            return response;
        }
    }
}
