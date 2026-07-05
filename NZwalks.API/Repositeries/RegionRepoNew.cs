using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Models;
using NZwalks.API.Models.DTO;

namespace NZwalks.API.Repositeries
{
    public class RegionRepoNew : IRegionInterface
    {
        private WalksDbContext dbContext;
        private IMapper _mapper;
        public RegionRepoNew(WalksDbContext DbContext, IMapper mapper) { 
            this.dbContext = DbContext;
            this._mapper = mapper;
        }

        public async Task<List<RegionDTO>> GetAllRegion()
        {

            var regions = await dbContext.Regions.ToListAsync();
            var regionDTOlist = _mapper.Map<List<RegionDTO>>(regions);
            //var regionDTOlist = new List<RegionDTO>();
            //foreach (var region in regions)
            //{
            //    regionDTOlist.Add(new RegionDTO()
            //    {
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageURL = region.RegionImageURL,
            //    });
            //}
            return regionDTOlist;
        }

    }
}
