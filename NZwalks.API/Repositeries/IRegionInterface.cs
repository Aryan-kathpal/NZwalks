using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Models.DTO;

namespace NZwalks.API.Repositeries
{
    public interface IRegionInterface
    {
        public Task<List<RegionDTO>> GetAllRegion();
    }
}
