using Microsoft.EntityFrameworkCore;
using PruebaTecnicaMyper.DAL.DataContext;
using PruebaTecnicaMyper.Domain.DTOs;
using PruebaTecnicaMyper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMyper.DAL.Repositories
{
    public class TrabajadorRepository : ITrabajadorRepository
    {
        private readonly MyperContext _context; 
        public TrabajadorRepository(MyperContext context)
        {
            _context = context;
        }
        public async Task<ReturnResponse<bool>> Add(Trabajador trabajador)
        {
            try
            {
                //VALIDAR EL NUMERO DE DOCUMENTO
                bool existDocumentNumber = await _context.Trabajadores.Where(t => t.NumeroDocumento == trabajador.NumeroDocumento).AnyAsync();
                if(existDocumentNumber) {
                    var errors = new Dictionary<string, List<string>>()
                    {
                        { "NumeroDocumento", new List<string>(){ "Ya existe este Nro. Documento en la base de Datos" } }
                    };
                    return new ReturnResponse<bool> { Message = "Error por duplicidad de campo único", Success = false, Errors = errors };
                }
                else
                {
                    await _context.Trabajadores.AddAsync(trabajador);
                    await _context.SaveChangesAsync();
                    return new ReturnResponse<bool> { Message = "Registro Agregado Correctamente", Success = true  };
                }
            }catch(Exception ex)
            {
                return new ReturnResponse<bool> { Message = "No se pudo agregar el registro", Success = false, Errors = new() { { "Exception", new List<string> { ex.Message } }}};
            }
        }
        public async Task<ReturnResponse<bool>> Delete(int id)
        {
            try
            {
                Trabajador? entity = await _context.Trabajadores.FindAsync(id);
                if (entity != null)
                {
                    _context.Trabajadores.Remove(entity);
                    await _context.SaveChangesAsync();
                    return new ReturnResponse<bool> { Message = "Registro Eliminado Correctamente", Success = true };
                }
                else
                {
                    return new ReturnResponse<bool> { Message = "No se encontró el trabajador en la base de datos", Success = false };
                }
            }
            catch (Exception ex)
            {
                return new ReturnResponse<bool> { Message = "No se pudo eliminar el registro", Success = false, Errors = new() { { "Exception", new List<string> { ex.Message } }}};
            }
        }
        public async Task<ReturnResponse<List<pMAINGET_TrabajadoresSelect>>> GetAll(string sexo = "")
        {
            try
            {
                List<pMAINGET_TrabajadoresSelect> trabajadores = await _context.Set<pMAINGET_TrabajadoresSelect>().FromSqlRaw("EXEC pMAINGET_TrabajadoresSelect @p0", sexo).ToListAsync();
                return new ReturnResponse<List<pMAINGET_TrabajadoresSelect>> { Data = trabajadores, Success = true, Message = "Se listó todos los trabajadores con éxito" };
            }
            catch (Exception ex) {
                return new ReturnResponse<List<pMAINGET_TrabajadoresSelect>> { Data = null, Success = false, Message = "Error al listar los trabajadores", Errors = new() { { "Exception", new List<string> { ex.Message } }}};
            }
        }
        public async Task<ReturnResponse<Trabajador>> GetById(int id)
        {
            try
            {
                Trabajador? trabajador = await _context.Trabajadores.FindAsync(id);
                if(trabajador != null)
                {
                    return new ReturnResponse<Trabajador> { Data = trabajador, Success = true, Message = "Se mostró los datos del trabajador con éxito" };
                }
                else
                {
                    return new ReturnResponse<Trabajador> { Data = null, Success = false, Message = "No se encontró al trabajador en la base de datos" };
                }
            }
            catch (Exception ex)
            {
                return new ReturnResponse<Trabajador> { Data = null, Success = false, Message = "Error al mostrar al trabajador", Errors = new() { { "Exception", new List<string> { ex.Message } }}};
            }
        }
        public async Task<ReturnResponse<bool>> Update(Trabajador trabajador)
        {
            try
            {
                bool existDocumentNumber = false;
                Trabajador? trabajadorDb = await _context.Trabajadores.AsNoTracking().FirstOrDefaultAsync(t => t.Id == trabajador.Id);
                ;
                if (trabajadorDb?.NumeroDocumento != trabajador.NumeroDocumento)
                {
                    existDocumentNumber = _context.Trabajadores.Any(t => t.NumeroDocumento == trabajador.NumeroDocumento && t.Id != trabajador.Id);
                }
                if (existDocumentNumber)
                {
                    var errors = new Dictionary<string, List<string>>()
                        {
                            { "NumeroDocumento", new List<string>(){ "Ya existe este Nro. Documento en la base de Datos" } }
                        };
                    return new ReturnResponse<bool> { Message = "Error por duplicidad de campo único", Success = false, Errors = errors };
                }
                else
                {
                    _context.Trabajadores.Update(trabajador);
                    await _context.SaveChangesAsync();
                }
                return new ReturnResponse<bool> { Message = "Registro Actualizado Correctamente", Success = true };
            }
            catch (Exception ex)
            {
                return new ReturnResponse<bool> { Message = "No se pudo actualizar el registro", Success = false, Errors = new() { { "Exception", new List<string> { ex.Message } }}};
            }
        }
    }
}
