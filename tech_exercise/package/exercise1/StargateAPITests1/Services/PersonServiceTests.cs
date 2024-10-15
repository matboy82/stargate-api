using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StargateAPI.Data;
using StargateAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateAPI.Services.Tests
{
	[TestClass()]
	public class PersonServiceTests
	{
		private Mock<IPersonService> _personServiceMock;
		private IPersonService _personService;

		[TestInitialize]
		public void Initialize()
		{
			_personServiceMock = new Mock<IPersonService>();
			_personService = _personServiceMock.Object;
		}

		[TestMethod()]
		public async Task PersonServiceTestAsync()
		{
			Assert.IsNotNull(_personService);
		}

		[TestMethod()]
		public async Task GetPersonTestAsync()
		{
			// Arrange
			var personId = 1;
			var person = new Person { Id = personId, Name = "Test Person" };
			_personServiceMock.Setup(x => x.GetPerson("Test Person")).ReturnsAsync(person);

			// Act
			var result = await _personService.GetPerson("Test Person");

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(person.Name, result.Name);
		}

		[TestMethod()]
		public async Task GetAllPeopleTestAsync()
		{
			// Arrange
			/*
			 * var person1 = new Person { Id = 1, Name = "Person 1" };
			var person2 = new Person { Id = 2, Name = "Person 2" };
			_personServiceMock.Setup(x => x.GetAllPeople()).Returns(new[] { person1, person2 });

			// Act
			var result = await _personService.GetAllPeople();

			// Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 2);
			Assert.IsTrue(result.Any(p => p.Name == person1.Name));
			Assert.IsTrue(result.Any(p => p.Name == person2.Name));
			*/
		}

		[TestMethod()]
		public async Task AddPersonTestAsync()
		{
			// Arrange 
			/*
			var person = new Person { Name = "Test Person" };
			_personServiceMock.Setup(x => x.AddPerson(person)).Returns(Task.CompletedTask.GetAwaiter);

			// Act
			await _personService.AddPerson(person);

			// Assert
			_personServiceMock.Verify(x => x.AddPerson(person), Times.Once);
			*/
		}

		[TestMethod()]
		public async Task UpdatePersonTestAsync()
		{
			/*
			// Arrange
			var person = new Person { Id = 1, Name = "Test Person" };
			_personServiceMock.Setup(x => x.UpdatePersonAsync(person)).Returns(Task.CompletedTask);

			// Act
			await _personService.UpdatePersonAsync(person);

			// Assert
			_personServiceMock.Verify(x => x.UpdatePersonAsync(person), Times.Once);
			*/
		}
	}
}