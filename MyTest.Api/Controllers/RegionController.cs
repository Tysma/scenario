using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyTest.Api.Models;

namespace MyTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        [HttpGet("{pays}")]
        public ActionResult<IEnumerable<RegionModel>> GetRegions(string pays)
        {
            if (pays.ToLower() == "france")
            {
                var regions = new List<RegionModel>
            {
                new RegionModel { Name = "Nouvelle-Aquitaine" },
                new RegionModel { Name = "Centre-Val de Loire" },
                new RegionModel { Name = "Grand Est" },
                new RegionModel { Name = "Hauts-de-France" },
                new RegionModel { Name = "Île-de-France" },
                new RegionModel { Name = "Normandy" },
                new RegionModel { Name = "Occitanie" },
                new RegionModel { Name = "Pays de la Loire" },
                new RegionModel { Name = "Provence-Alpes-Côte d'Azur" }
            };


                return Ok(regions);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
