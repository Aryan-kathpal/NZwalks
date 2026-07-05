using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Models;
using NZwalks.API.Models.DTO;
using NZwalks.API.Repositeries;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private WalksDbContext dbcontext;
        private IRegionInterface regionInterface;
        public RegionController(WalksDbContext dbContext, IRegionInterface regionInterface)
        {
            this.dbcontext = dbContext;
            this.regionInterface = regionInterface;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionDTOlist = await regionInterface.GetAllRegion();
            return Ok(regionDTOlist);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var region = dbcontext.Regions.FirstOrDefault(r => r.Name == name);
            RegionDTO regionDTO = new RegionDTO();
            if (region == null)
            {
                return NotFound();
            }
            regionDTO.Name = region.Name;
            regionDTO.RegionImageURL = region.RegionImageURL;
            regionDTO.Code = region.Code;
            
            return Ok(regionDTO);
        }

        [HttpPost]
        public IActionResult createRegion(RegionDTO region)
        {
            var Region = new Region
            {
                RegionImageURL = region.RegionImageURL,
                Name = region.Name,
                Code = region.Code
            };

            dbcontext.Regions.Add(Region);
            dbcontext.SaveChanges();

            return CreatedAtAction(nameof(GetByName), new {name = region.Name} , region );
        }
    }
}
