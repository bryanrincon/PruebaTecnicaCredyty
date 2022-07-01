using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRegistroRepository
    {
        Task<IList<Registro>> GetAll();
        Task<IList<Registro>> GetxPlaca(string placa);
        Task<int> Insert(Registro registro);
        Task<int> Update(Registro registro);
        Task<IList<Registro>> GetxDateRange(DateTime startDate, DateTime endDate);
    }
}
