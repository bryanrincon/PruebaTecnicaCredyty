using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Interfaces
{
    public interface IRegistroBusiness
    {
        Task<ApiResult> GetAll();
        Task<ApiResult> GetxPlaca(string placa);
        Task<ApiResult> GetxDateRange(DateTime startDate, DateTime endDate);
        Task<ApiResult> Insert(RegistroRequest registro);
        Task<ApiResult> Update(RegistroRequest registro);
    }
}
