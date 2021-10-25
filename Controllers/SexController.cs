using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Sexes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class SexController : BaseApiController
    {
        private readonly ISexService _sexService;

        public SexController(ISexService sexService)
        {
            _sexService = sexService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResult<GetSexDTO[]>>> GetAllSexes()
        {
            return await _sexService.GetAllSexesAsync();
        }
    }
}
