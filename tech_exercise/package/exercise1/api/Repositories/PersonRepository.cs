using Microsoft.EntityFrameworkCore;
using StargateAPI.Data;
using StargateAPI.Repositories;
using StargateAPI.Services;
namespace StargateAPI.Repositories
{
	public class PersonRepository : IPersonRepository
	{
		private readonly StargateContext _context;
		public PersonRepository(StargateContext context)
		{
			_context = context;
		}
		public async Task<bool> AddPerson(Person person)
		{
			var existingPerson = await _context.People.Where(x => x.Name == person.Name).FirstOrDefaultAsync();
			if (existingPerson != null)
			{
				return false;// person already exists
			}

			await _context.People.AddAsync(person);
			var result = await _context.SaveChangesAsync();
			if (result == 1)
			{				
				return true;
			}

			return false;
		}

		public async Task<Person> GetPerson(string name)
		{
			var person = await _context.People.Where(x => x.Name == name).FirstOrDefaultAsync();
			if (person == null)
			{
				return null;
			}
			person.AstronautDuties = await _context.AstronautDuties.Where(x => x.PersonId == person.Id).ToListAsync();
			person.AstronautDetail= await _context.AstronautDetails.Where(x => x.PersonId == person.Id).FirstOrDefaultAsync();
			return person;
		}

		public async Task<List<Person>> GetPersons()
		{
			var people = await _context.People
				.Include(p => p.AstronautDuties)
				.Include(p => p.AstronautDetail)
				.ToListAsync();
	
			return people;
		}

		public async Task<bool> UpdatePerson(Person person)
		{
			var existingPerson = await _context.People.Where(x => x.Name == person.Name).FirstOrDefaultAsync();
			if (existingPerson == null)
			{
				return false;
			}
			
			existingPerson = person;

			_context.People.Update(existingPerson);
			var result = await _context.SaveChangesAsync();
			if (result == 1)
			{
				return true;
			}
			return false;
		}
	}
}
