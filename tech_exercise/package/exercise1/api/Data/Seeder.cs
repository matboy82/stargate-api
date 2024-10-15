using Microsoft.EntityFrameworkCore;

namespace StargateAPI.Data
{
	public class Seeder
	{
		private readonly StargateContext _context;
		public Seeder(StargateContext context)
		{
			_context = context;
			context.Database.EnsureCreated();
		}

		public void Seed()
		{
			if (_context.People.Any())
			{
				return; // DB has been seeded
			}

			var persons = new List<Person>
			{
				new Person { Id = 1, Name = "John Doe" },
				new Person { Id = 2, Name = "Jane Doe" }
			};

			

			var astronautDetails = new List<AstronautDetail>
			{
				new AstronautDetail
				{
					Id = 1,
					PersonId = 1,
					CurrentRank = "1LT",
					CurrentDutyTitle = "Commander",
					CareerStartDate = DateTime.Now
				}
			};

			
			var astronautDuties = new List<AstronautDuty>
			{
				new AstronautDuty
				{
					Id = 1,
					PersonId = 1,
					DutyStartDate = DateTime.Now,
					DutyTitle = "Commander",
					Rank = "1LT"
				}
			};

			_context.People.AddRange(persons);
			_context.AstronautDetails.AddRange(astronautDetails);
			_context.AstronautDuties.AddRange(astronautDuties);
			_context.SaveChanges();
		}
	}
}
