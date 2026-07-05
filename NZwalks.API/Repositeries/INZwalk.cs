using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Models;
using NZwalks.API.Models.DTO;

namespace NZwalks.API.Repositeries
{
    public interface INZwalk
    {
        Task<Walk> addWalkRepo(NZwalkRequest request);
        Task<List<NZwalkResponse>> getAll();
    }
}
