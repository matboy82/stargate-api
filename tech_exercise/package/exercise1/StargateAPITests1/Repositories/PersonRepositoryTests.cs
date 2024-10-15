using Microsoft.VisualStudio.TestTools.UnitTesting;
using StargateAPI.Data;
using StargateAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace StargateAPI.Repositories.Tests
{
	[TestClass()]
	public class PersonRepositoryTests
	{
		private readonly IPersonRepository _repository;

		public PersonRepositoryTests(IPersonRepository repository)
		{
			var mockRepository = new Mock<IPersonRepository>();
			_repository = mockRepository.Object;
		}

		[TestMethod()]
		public void PersonRepositoryTest()
		{
			Assert.IsNotNull(_repository);
		}

		[TestMethod()]
		public async void AddPersonTest()
		{
			var person = new Person { Name = "Test Person" };
			await _repository.AddPerson(person);

			var result = await _repository.GetPerson(person.Name);

			Assert.IsNotNull(result);
			Assert.AreEqual(person.Name, result.Name);
		}

		[TestMethod()]
		public async void GetPersonTest()
		{
			var person = new Person { Name = "Test Person" };
			await _repository.AddPerson(person);

			var result = await _repository.GetPerson(person.Name);

			Assert.IsNotNull(result);
			Assert.AreEqual(person.Name, result.Name);
		}

		[TestMethod()]
		public async void GetPersonsTest()
		{
			var person1 = new Person { Name = "Person 1" };
			var person2 = new Person { Name = "Person 2" };
			await _repository.AddPerson(person1);
			await _repository.AddPerson(person2);

			var result = await _repository.GetPersons();

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 2);
			Assert.IsTrue(result.Any(p => p.Name == person1.Name));
			Assert.IsTrue(result.Any(p => p.Name == person2.Name));
		}

		[TestMethod()]
		public async void UpdatePersonTest()
		{
			/*
			var person = new Person { Name = "Test Person" };
			await _repository.AddPerson(person);

			person.Name = "Updated Person";
			await _repository.UpdatePerson(person);

			var result = await _repository.GetPerson(person.Id);

			Assert.IsNotNull(result);
			Assert.AreEqual(person.Name, result.Name);
			*/
		}
	}
}