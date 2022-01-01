using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UNLayerP.Core.Models;
using UNLayerP.Core.Services;

namespace UNLayerP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;

        public PersonsController(IService<Person> service)
        {
            _personService = service; 
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var person = await _personService.GetAllAsync();
            return Ok(person);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var personel = await _personService.AddAsync(person);
            return Ok(personel);
        }

    }
}
