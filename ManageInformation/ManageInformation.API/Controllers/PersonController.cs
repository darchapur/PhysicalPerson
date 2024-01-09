using Microsoft.AspNetCore.Mvc;
using ManageInformation.Infrastructure.Interfaces;
using ManageInformation.Domain.Model;
using ManageInformation.Infrastructure.DTO;

namespace ManageInformation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonInterface _PersonRepository;

        public PersonController(PersonInterface PersonRepository)
        {
            _PersonRepository= PersonRepository;
        }

        [HttpGet]
        public ICollection<Person> GetPersons()
        {
            var Persons = _PersonRepository.GetPersons();
            return Persons;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPersonById(int id)
        {
            var Person = _PersonRepository.GetPersonsById(id);

            if (Person == null)
            {
                // Если Person не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            //var PersonDto = PersonDtoMapper.ToDto(Person);
            return Ok(Person);
        }
        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person createPerson)
        {
            if (createPerson == null)
            {
                return BadRequest(ModelState);
            }

            /*var Person = _PersonRepository.GetPersons()
                .Where(c => c.Id == createPerson.)
                .FirstOrDefault();

            if (Person != null)
            {
                ModelState.AddModelError("", "Person with this id already exist");
                return StatusCode(442, ModelState);
            }*/

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var newPerson = PersonDtoMapper.ToPerson(createPerson);

            if (!_PersonRepository.CreatePerson(createPerson))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfull created");
        }
        [HttpPut("{PersonId}")]
        public IActionResult UpdatePerson(int PersonId, [FromBody] Person updatePerson)
        {
            if (updatePerson == null)
            {
                return BadRequest(ModelState);
            }

            if (PersonId != updatePerson.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_PersonRepository.UpdatePerson(updatePerson))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            
                   
            return NoContent();
        }
        [HttpDelete("{PersonId}")]
        public IActionResult DeletePerson(int PersonId)
        {
            if (!_PersonRepository.PersonExists(PersonId))
            {
                return NotFound();
            }

            var removePerson = _PersonRepository.GetPersonsById(PersonId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_PersonRepository.DeletePerson(removePerson))
            {
                ModelState.AddModelError("", "Something went wrong");

            }

            return NoContent();
        }
    }
}