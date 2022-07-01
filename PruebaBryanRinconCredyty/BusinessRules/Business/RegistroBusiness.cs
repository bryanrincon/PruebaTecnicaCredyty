using BusinessRules.Interfaces;
using DataAccess.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Business
{
    public class RegistroBusiness : IRegistroBusiness
    {
        private readonly IRegistroRepository _repository;
        private readonly ITipoVehiculoRepository _tipoRepository;
        public RegistroBusiness(IRegistroRepository repository, ITipoVehiculoRepository tipoRepository)
        {
            _repository = repository;
            _tipoRepository = tipoRepository;
        }

        public async Task<ApiResult> GetAll()
        {
            ApiResult apiResult = new ApiResult();
            try
            {
                apiResult.Result = await _repository.GetAll();
                apiResult.Message = "Ok";
                apiResult.Error = string.Empty;
            }
            catch (Exception ex)
            {
                apiResult.Message = "Error";
                apiResult.Error = ex.Message;
            }
            return apiResult;
        }

        public async Task<ApiResult> GetxPlaca(string placa)
        {
            ApiResult apiResult = new ApiResult();
            try
            {
                apiResult.Result = await _repository.GetxPlaca(placa);
                apiResult.Message = "Ok";
                apiResult.Error = string.Empty;
            }
            catch (Exception ex)
            {
                apiResult.Message = "Error";
                apiResult.Error = ex.Message;
            }
            return apiResult;
        }

        public async Task<ApiResult> GetxDateRange(DateTime startDate, DateTime endDate)
        {
            ApiResult apiResult = new ApiResult();
            try
            {
                apiResult.Result = await _repository.GetxDateRange(startDate, endDate);
                apiResult.Message = "Ok";
                apiResult.Error = string.Empty;
            }
            catch (Exception ex)
            {
                apiResult.Message = "Error";
                apiResult.Error = ex.Message;
            }
            return apiResult;
        }

        public async Task<ApiResult> Insert(RegistroRequest registro)
        {
            ApiResult apiResult = new ApiResult();
            try
            {
                var _validVehiculo = await _repository.GetxPlaca(registro.Placa);
                if (_validVehiculo.Count > 0)
                {
                    if (_validVehiculo.Where(x=>x.Salida == null).ToList().Count > 0)
                    {
                        apiResult.Result = "El vehículo aun no ha salido";
                        apiResult.Message = "Ok";
                        apiResult.Error = string.Empty;
                        return apiResult;
                    }
                }
                var _tiposVehiculos = await _tipoRepository.GetAll();
                if (_tiposVehiculos.Where(x=>x.Id == registro.IdTipoVehiculo).ToList().Count > 0)
                {
                    apiResult.Result = await _repository.Insert(new Registro
                    {
                        IdTipoVehiculo = registro.IdTipoVehiculo,
                        Ingreso = registro.Ingreso,
                        Placa = registro.Placa,
                    });
                    apiResult.Message = "Ok";
                    apiResult.Error = string.Empty;
                }
                else
                {
                    apiResult.Result = "No se encontro el tipo de vehículo";
                    apiResult.Message = "NoResults";
                    apiResult.Error = string.Empty;
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = "Error";
                apiResult.Error = ex.Message;
            }
            return apiResult;
        }

        public async Task<ApiResult> Update(RegistroRequest registro)
        {
            ApiResult apiResult = new ApiResult();
            try
            {
                var _vehiculodata = await _repository.GetxPlaca(registro.Placa);
                var _vehiculo = _vehiculodata.Where(x=>x.Salida == null);
                var _tipoVehiculo = await _tipoRepository.GetAll();
                if (_vehiculo.Count() > 0)
                {
                    if (_tipoVehiculo.Count > 0)
                    {
                        TimeSpan _timespan = registro.Salida.Value - registro.Ingreso;
                        decimal _totalMinutes = Convert.ToDecimal(_timespan.TotalMinutes);
                        var _rate = _tipoVehiculo.Where(x => x.Id == _vehiculo.FirstOrDefault().IdTipoVehiculo).FirstOrDefault().Tarifa;
                        decimal _subTotal = (_rate * _totalMinutes);
                        decimal _totalPaid = _subTotal;
                        decimal _discountValue = 0;
                        if (registro.Factura.Trim() != String.Empty)
                        {
                            var _discount = (_subTotal * 30) / 100;
                            _discountValue = _discount;
                            _totalPaid = _subTotal - _discount;
                        }
                        Registro _data = new Registro
                        {
                            Id = _vehiculo.FirstOrDefault().Id,
                            IdTipoVehiculo = _vehiculo.FirstOrDefault().IdTipoVehiculo,
                            Ingreso = _vehiculo.FirstOrDefault().Ingreso,
                            Salida = registro.Salida,
                            Placa = _vehiculo.FirstOrDefault().Placa,
                            Factura = registro.Factura.Trim(),
                            SubTotal = _subTotal,
                            ValorDescuento = _discountValue,
                            TotalPagado = _totalPaid
                        };
                        await _repository.Update(_data);
                        apiResult.Result = _data;
                        apiResult.Message = "Ok";
                        apiResult.Error = string.Empty;
                    }
                    else
                    {
                        apiResult.Result = "No se encontro el tipo de vehículo";
                        apiResult.Message = "NoResults";
                        apiResult.Error = string.Empty;
                    }
                }
                else
                {
                    apiResult.Result = $"No se encontro la placa {registro.Placa}";
                    apiResult.Message = "NoResults";
                    apiResult.Error = string.Empty;
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = "Error";
                apiResult.Error = ex.Message;
            }
            return apiResult;
        }
    }
}
