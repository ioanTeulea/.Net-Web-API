using Project.Database.Dtos.Request;
using Project.Database.Entities;
using Project.Database.Repositories;
using System.Collections.Generic;
using Project.Core.Mapping;
using Project.Database.Dtos.Response;
using Project.Database.QueryExtensions;

namespace Project.Core.Services
{
    public class ProdusService
    {
        private readonly ProdusRepository _produsRepository;

        public ProdusService(ProdusRepository produsRepository)
        {
            _produsRepository = produsRepository;
        }

        public GetProduseResponse GetAllProduse(GetProduseRequest payload)
        {
            var produse= _produsRepository.GetAllProduse(payload);
          
            var result = new GetProduseResponse();
            result.Produse = produse.ToProdusDtos();
            result.Count = _produsRepository.CountProduse(payload);
            return result;
        }

        public GetProdusResponse GetProdusById(int id)
        {
            var produs=_produsRepository.GetProdusById(id);
            var result = produs.ToGetProdusResponse();
            return result;
        }
        public Produs AddProdus(AddProdusRequest request)
        {
            var produs = request.ToEntity();
            _produsRepository.AddProdus(produs);
            return produs;
        }
    }
}
