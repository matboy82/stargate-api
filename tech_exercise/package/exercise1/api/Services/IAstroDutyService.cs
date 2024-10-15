using StargateAPI.Data;

namespace StargateAPI.Services
{
	public interface IAstroDutyService
	{
		Task<List<AstronautDuty>> GetByName(string name);
		Task<bool> AddDuty(AstronautDuty astroDuty);
	}
}
