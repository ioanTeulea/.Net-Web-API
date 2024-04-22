using Project.Core.Services;
using Project.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult<IEnumerable<Produs>> GetAllProduse()
        {
            var produse = _produsService.GetAllProduse();
            return Ok(produse);
        }

        [HttpGet("{id}")]
        public ActionResult<Produs> GetProdusById(int id)
        {
            var produs = _produsService.GetProdusById(id);
            if (produs == null)
            {
                return NotFound();
            }
            return Ok(produs);
        }
    }
}
