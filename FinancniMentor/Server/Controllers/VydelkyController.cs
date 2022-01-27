using Microsoft.AspNetCore.Mvc;
using FinancniMentor.Server.Storage;
using FinancniMentor.Shared;

namespace FinancniMentor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VydelkyController : ControllerBase
    {
        private readonly IRepository<Vydelek> _vydelekRepository;

        public VydelkyController(IRepository<Vydelek> vydelekRepository)
        {
            _vydelekRepository = vydelekRepository;
        }

        [HttpGet]
        public IEnumerable<Vydelek> Get()
        {
            return _vydelekRepository.GetAll()
                .OrderBy(vydelek => vydelek.Datum);
        }

        [HttpPost]
        public void Post(Vydelek vydelek)
        {
            _vydelekRepository.Add(vydelek);
        }

        [HttpDelete("{id?}")]
        public void Delete(Guid id)
        {
            var entity = _vydelekRepository.GetAll()
                .Single(item => item.Id == id);
            _vydelekRepository.Remove(entity);
        }
    }
}
