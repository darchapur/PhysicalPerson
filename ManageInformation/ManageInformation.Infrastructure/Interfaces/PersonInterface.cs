using ManageInformation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Infrastructure.Interfaces
{
    public interface PersonInterface
    {
        ICollection<Person> GetPersons();
        Person GetPersonsById(int id);
        bool CreatePerson(Person person);
        bool UpdatePerson(Person person);
        bool DeletePerson(Person person);
        bool PersonExists(int id);
        bool Save();
    }
}
