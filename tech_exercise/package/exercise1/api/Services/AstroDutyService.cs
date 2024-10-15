using StargateAPI.Data;
using StargateAPI.Repositories;

namespace StargateAPI.Services
{
	public class AstroDutyService : IAstroDutyService
	{
		private readonly IAstroDutyRepository _repository;

		public AstroDutyService(IAstroDutyRepository repository)
		{
			_repository = repository;
		}

		public async Task<bool> AddDuty(AstronautDuty astroDuty)
		{
			//A Person's Previous Duty End Date is set to the day before the New Astronaut Duty Start Date when a new Astronaut Duty is received for a Person.
			var duty = await _repository.GetDuties(astroDuty.PersonId);

			if(duty.Count > 0)
			{
				duty[duty.Count - 1].DutyEndDate = astroDuty.DutyStartDate.AddDays(-1);
				await _repository.UpdateDuty(duty[duty.Count - 1]);
			}

			if (astroDuty.DutyTitle == "Retired" || astroDuty.DutyTitle == "RETIRED")
			{
				astroDuty.DutyEndDate = astroDuty.DutyStartDate.AddDays(-1); //retired career end date is a day before the start date
			}
			else
			{
				astroDuty.DutyEndDate = null;// enforce no end date for active duty
			}
			
			return await _repository.AddDuty(astroDuty);
		}

		public async Task<List<AstronautDuty>> GetByName(string name)
		{
			return await _repository.GetByName(name);
		}
	}
}
