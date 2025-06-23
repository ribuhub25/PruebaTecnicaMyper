using PruebaTecnicaMyper.Domain.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaMyper.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ReturnResponse<bool>> Add(T entity);
        Task<ReturnResponse<bool>> Update(T entity);
        Task<ReturnResponse<bool>> Delete(int id);
        Task<ReturnResponse<T>> GetById(int id);
    }

    public class ReturnResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T? Data { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public ReturnResponse()
        {
            Errors = new Dictionary<string, List<string>>();
        }
    }
}

