using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ITipoVehiculoRepository
    {
        Task<IList<TipoVehiculo>> GetAll();
    }
}
