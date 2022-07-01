using Dapper;
using DataAccess.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Business
{
    public class TipoVehiculoRepository : ITipoVehiculoRepository
    {
        private readonly IDapperRepository _repository;
        public TipoVehiculoRepository(IDapperRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<TipoVehiculo>> GetAll()
        {
            using (var _db = _repository.GetContext)
            {
                var _result = await _db.QueryAsync<TipoVehiculo>(@"SELECT
	                                                            Id,
	                                                            Tipo,
	                                                            Tarifa
                                                            FROM
	                                                            TipoVehiculo", commandType: System.Data.CommandType.Text);
                return _result.ToList();
            }
        }
    }
}
