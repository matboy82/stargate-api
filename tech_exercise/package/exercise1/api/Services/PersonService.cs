using StargateAPI.Data;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Repositories;
using StargateAPI.Services;
namespace StargateAPI.Services
{
	public class PersonService: IPersonService
	{
		private readonly IPersonRepository _personRepository;
		public PersonService(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public async Task<Person> GetPerson(string name)
		{
			return await _personRepository.GetPerson(name);	
		}

		public async Task<List<Person>> GetAllPeople()
		{
			return await _personRepository.GetPersons();
		}

		public async Task<bool> AddPerson(Person person)
		{
			return await _personRepository.AddPerson(person);
		}

		public async Task<bool> UpdatePerson(Person person)
		{
			return await _personRepository.UpdatePerson(person);
		}
	}
}
