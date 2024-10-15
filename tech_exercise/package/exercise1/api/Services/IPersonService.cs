using StargateAPI.Data;

namespace StargateAPI.Services
{
	public interface IPersonService
	{
		public Task<List<Person>> GetAllPeople();
		public Task<Person>  GetPerson(string name);
		public Task<bool> AddPerson(Person person);
		public Task<bool> UpdatePerson(Person person);
	}
}
