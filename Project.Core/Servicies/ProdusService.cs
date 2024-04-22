using Project.Database.Dtos.Request;
using Project.Database.Entities;
using Project.Database.Repositories;
using System.Collections.Generic;
using Project.Core.Mapping;

namespace Project.Core.Services
{
    public class ProdusService
    {
        private readonly ProdusRepository _produsRepository;

        public ProdusService(ProdusRepository produsRepository)
        {
            _produsRepository = produsRepository;
        }

        public IEnumerable<Produs> GetAllProduse()
        {
            return _produsRepository.GetAllProduse();
        }

        public Produs GetProdusById(int id)
        {
            return _produsRepository.GetProdusById(id);
        }
        public Produs AddProdus(AddProdusRequest request)
        {
            var produs = request.ToEntity();
            _produsRepository.AddProdus(produs);
            return produs;
        }
    }
}
