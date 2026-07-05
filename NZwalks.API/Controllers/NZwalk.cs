using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Models;
using NZwalks.API.Models.DTO;
using NZwalks.API.Repositeries;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NZwalk : ControllerBase
    {
        private INZwalk _nzwalk;
        private IMapper _mapper;

        public NZwalk(INZwalk nZwalk,IMapper mapper)
        {
            this._nzwalk = nZwalk;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var response = await _nzwalk.getAll();
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> AddWalk(NZwalkRequest walk)
        {
            var nzwalk = await _nzwalk.addWalkRepo(walk);
            var response = _mapper.Map<NZwalkResponse>(nzwalk);
            return Ok(response);
        }
    }
}
