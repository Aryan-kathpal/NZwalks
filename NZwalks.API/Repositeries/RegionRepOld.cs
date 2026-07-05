using NZwalks.API.Data;
using NZwalks.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Models;

namespace NZwalks.API.Repositeries
{
    public class RegionRepOld : IRegionInterface
    {
        private WalksDbContext dbContext;
        public RegionRepOld(WalksDbContext DbContext)
        {
            this.dbContext = DbContext;
        }

        public async Task<List<RegionDTO>> GetAllRegion()
        {

            var regions = await dbContext.Regions.ToListAsync();
            var regionDTOlist = new List<RegionDTO>();
            foreach (var region in regions)
            {
                regionDTOlist.Add(new RegionDTO()
                {
                    Name = region.Name,
                    Code = region.Name,
                    RegionImageURL = region.RegionImageURL,
                });
            }
            return regionDTOlist;
        }

    }
}
