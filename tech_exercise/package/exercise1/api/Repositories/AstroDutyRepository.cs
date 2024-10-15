using Microsoft.EntityFrameworkCore;
using StargateAPI.Data;

namespace StargateAPI.Repositories
{
	public class AstroDutyRepository : IAstroDutyRepository
	{
		private readonly StargateContext _context;
		public AstroDutyRepository(StargateContext context)
		{
			_context = context;
		}

		public async Task<bool> AddDuty(AstronautDuty astroDuty)
		{
			_context.AstronautDuties.Add(astroDuty);
			try
			{
				var result = await _context.SaveChangesAsync();

				if (result == 1)
				{
					return true;
				}
			} catch(Exception ex) 
			{
				return false;
			}
			
			return false;
		}

		public async Task<List<AstronautDuty>> GetByName(string name)
		{
			var person = await _context.People.Where(x => x.Name == name).FirstOrDefaultAsync();
			if (person == null)
			{
				return null;
			}
			return await _context.AstronautDuties.Where(x => x.PersonId == person.Id).ToListAsync();
		}

		public async Task<List<AstronautDuty>> GetDuties(int personId)
		{
			return await _context.AstronautDuties.Where(x => x.PersonId == personId).ToListAsync();
		}

		public async Task<bool> UpdateDuty(AstronautDuty astroDuty)
		{
			_context.AstronautDuties.Update(astroDuty);
			var result = await _context.SaveChangesAsync();
			if (result == 1)
			{
				return true;
			}
			return false;
		}
	}
}
