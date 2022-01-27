using Microsoft.AspNetCore.Mvc;
using FinancniMentor.Server.Storage;
using FinancniMentor.Shared;

namespace FinancniMentor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VydajeController : ControllerBase
    {
        private readonly IRepository<Vydaj> _vydajRepository;

        public VydajeController(IRepository<Vydaj> vydajRepository)
        {
            _vydajRepository = vydajRepository;
        }

        [HttpGet]
        public IEnumerable<Vydaj> Get()
        {
            return _vydajRepository.GetAll()
                .OrderBy(earning => earning.Datum);
        }

        [HttpPost]
        public void Post(Vydaj vydaj)
        {
            _vydajRepository.Add(vydaj);
        }

        [HttpDelete("{id?}")]
        public void Delete(Guid id)
        {
            var entity = _vydajRepository.GetAll()
                .Single(item => item.Id == id);
            _vydajRepository.Remove(entity);
        }
    }
}
