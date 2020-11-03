using Domain.Business;
using Moq;
using NUnit.Framework;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Tests
{
    [TestFixture()]
    public class ExampleRepositoryTests
    {
        [Test()]
        public void ExampleRepository_WhenCalled_InsertsAObjectOnDatabase()
        {
            // Arrange

            // Arrange
            var testObject = new ExampleClass();

            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<ExampleClass>>();
            context.Setup(x => x.Set<ExampleClass>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<ExampleClass>())).Returns(testObject);

            // Act
            var repository = new ExampleRepository(context.Object);
            repository.Inserir(testObject);

            //Assert
            context.Verify(x => x.Set<ExampleClass>());
            dbSetMock.Verify(x => x.Add(It.Is<ExampleClass>(y => y == testObject)));

        }
    }
}