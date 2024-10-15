using StargateAPI.Data;

namespace StargateAPI.Repositories
{
	public interface IAstroDutyRepository
	{
		Task<List<AstronautDuty>> GetByName(string name);
		Task<bool> AddDuty(AstronautDuty duty);
		Task<List<AstronautDuty>> GetDuties(int personId);
		Task<bool> UpdateDuty(AstronautDuty duty);
	}
}
