using StargateAPI.Data;

namespace StargateAPI.Repositories
{
	public interface IPersonRepository
	{
		Task<Person> GetPerson(string name);
		Task<List<Person>> GetPersons();
		Task<bool> AddPerson(Person person);
		Task<bool> UpdatePerson(Person person);
	}
}
