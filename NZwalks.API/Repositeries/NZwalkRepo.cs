using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Controllers;
using NZwalks.API.Data;
using NZwalks.API.Models;
using NZwalks.API.Models.DTO;

namespace NZwalks.API.Repositeries
{
    public class NZwalkRepo : INZwalk
    {
        private WalksDbContext _dbContext;
        private IMapper _mapper;
        public NZwalkRepo(WalksDbContext dbContext,IMapper mapper) {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        public async Task<Walk> addWalkRepo(NZwalkRequest request)
        {
            var nzwalk = _mapper.Map < Walk >(request);
            await _dbContext.Walks.AddAsync(nzwalk);
            _dbContext.SaveChanges();
            return nzwalk;
        }

        public async Task<List<NZwalkResponse>> getAll()
        {
            var walks = await _dbContext.Walks.Include(x=>x.Difficulty).Include(x=>x.Region).ToListAsync();
            var response = _mapper.Map<List<NZwalkResponse> >(walks);
            return response;
        }
    }
}
