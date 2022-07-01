using Dapper;
using DataAccess.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Business
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly IDapperRepository _repository;
        public RegistroRepository(IDapperRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<Registro>> GetAll()
        {
            using (var _db = _repository.GetContext)
            {
                var _result = await _db.QueryAsync<Registro>(@"SELECT
	                                            Id,
	                                            IdTipoVehiculo,
	                                            Placa,
	                                            Ingreso,
	                                            Salida,
	                                            Factura,
	                                            SubTotal,
	                                            ValorDescuento,
	                                            TotalPagado
                                            FROM
	                                            Registro", commandType: System.Data.CommandType.Text);
				return _result.ToList();

			}
        }

		public async Task<IList<Registro>> GetxPlaca(string placa)
		{
			using (var _db = _repository.GetContext)
			{
				var _result = await _db.QueryAsync<Registro>($@"SELECT
	                                            Id,
	                                            IdTipoVehiculo,
	                                            Placa,
	                                            Ingreso,
	                                            Salida,
	                                            Factura,
	                                            SubTotal,
	                                            ValorDescuento,
	                                            TotalPagado
                                            FROM
	                                            Registro
											WHERE 
												Placa = '{placa}'", commandType: System.Data.CommandType.Text);
				return _result.ToList();
			}
		}

		public async Task<IList<Registro>> GetxDateRange(DateTime startDate, DateTime endDate)
		{
			using (var _db = _repository.GetContext)
			{
				var _result = await _db.QueryAsync<Registro>($@"SELECT
	                                            Id,
	                                            IdTipoVehiculo,
	                                            Placa,
	                                            Ingreso,
	                                            Salida,
	                                            Factura,
	                                            SubTotal,
	                                            ValorDescuento,
	                                            TotalPagado
                                            FROM
	                                            Registro
											WHERE 
												Ingreso BETWEEN '{startDate:yyyy/MM/dd}' AND '{endDate:yyyy/MM/dd}'", commandType: System.Data.CommandType.Text);
				return _result.ToList();
			}
		}

		public async Task<int> Insert(Registro registro)
        {
            using (var _db = _repository.GetContext)
            {
                return await _db.ExecuteAsync(@"INSERT INTO Registro 
													(IdTipoVehiculo,
													Placa,
													Ingreso)
												VALUES
													(@IdTipoVehiculo,
													@Placa,
													@Ingreso)",new 
												{
													registro.IdTipoVehiculo,
													registro.Placa,
													registro.Ingreso
												});
            }

        }

		public async Task<int> Update(Registro registro)
		{
			using (var _db = _repository.GetContext)
			{
				return await _db.ExecuteAsync(@"UPDATE Registro 
													SET 
													Salida = @Salida,
													Factura = @Factura,
													SubTotal = @SubTotal,
													ValorDescuento = @ValorDescuento,
													TotalPagado = @TotalPagado
												WHERE
													Id = @Id", new
				{
					registro.Id,
					registro.Salida,
					registro.Factura,
					registro.SubTotal,
					registro.ValorDescuento,
					registro.TotalPagado
				});
			}

		}
	}
}
