using Project.Core.Services;
using Project.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Project.Database.Dtos.Request;

namespace LabProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdusController : ControllerBase
    {
        private readonly ProdusService _produsService;

        public ProdusController(ProdusService produsService)
        {
            _produsService = produsService;
        }

        [HttpPost]
        [Route("get-products")]
        public IActionResult GetAllProduse([FromBody] GetProduseRequest payload )
        {
            var produse = _produsService.GetAllProduse(payload);
            return Ok(produse);
        }

        [HttpGet]
        [Route("{produsId}/get-details")]
        public IActionResult GetProdusById([FromRoute] int produsId)
        {
            var produs = _produsService.GetProdusById(produsId);
            if (produs == null)
            {
                return NotFound();
            }
            return Ok(produs);
        }
    }
}
