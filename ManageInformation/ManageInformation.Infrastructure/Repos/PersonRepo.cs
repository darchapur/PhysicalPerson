using ManageInformation.Domain.Model;
using ManageInformation.Infrastructure.Data;
using ManageInformation.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Infrastructure.Repos
{
    public class PersonRepo : PersonInterface
    {
        private readonly Context _context;
        public PersonRepo(Context context)
        {
            _context = context;
        }

        public bool CreatePerson(Person person)
        {
            _context.Add(person);
            return Save();
        }

        public bool DeletePerson(Person person)
        {
            _context.Remove(person);
            return Save();
        }

        public ICollection<Person> GetPersons()
        {
            return _context.person.OrderBy(x => x.Id).ToList();
        }

        public Person GetPersonsById(int id)
        {
            return _context.person.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool PersonExists(int id)
        {
            return _context.person.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePerson(Person person)
        {
            _context.Update(person);
            return Save();
        }
    }
}
