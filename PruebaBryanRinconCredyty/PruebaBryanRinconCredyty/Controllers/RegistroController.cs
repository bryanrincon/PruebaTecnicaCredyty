using BusinessRules.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaBryanRinconCredyty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroBusiness _registroBusiness;
        public RegistroController(IRegistroBusiness registroBusiness)
        {
            _registroBusiness = registroBusiness;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult> GetAll()
        {
            return await _registroBusiness.GetAll();
        }

        [HttpGet("GetxPlaca/{placa}")]
        public async Task<ApiResult> GetxPlaca(string placa)
        {
            return await _registroBusiness.GetxPlaca(placa);
        }

        [HttpGet("GetxDateRange")]
        public async Task<ApiResult> GetxDateRange(DateTime startDate, DateTime endDate)
        {
            return await _registroBusiness.GetxDateRange(startDate, endDate);
        }


        [HttpPost("NewRecord")]
        public async Task<ApiResult> NewRecord(RegistroRequest registro)
        {
            return await _registroBusiness.Insert(registro);
        }

        [HttpPost("UpdateRecord")]
        public async Task<ApiResult> UpdateRecord(RegistroRequest registro)
        {
            return await _registroBusiness.Update(registro);
        }
    }
}
