using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Arcus.Domain.Model;
using API.Arcus.Infrastructure.Concrete.Query;
using API.Arcus.Infrastructure.Repository;
using AutoFixture.Xunit2;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace API.Arcus.Infrastructure.Test
{
	public class UserInfrastructureTest
	{
		[Theory]
		[DefaultData(typeof(UserObjectsMock))]
		public async Task GetUserByEmail_ShouldReturnValidUser(
			[Frozen] Mock<IRepository<User>> mockRepository,
			List<User> users,
			GetUserByEmailQueryHandler sut)
		{
			// Arrange
			var mockList = users.AsQueryable().BuildMock();
			mockRepository.Setup(x => x.GetAll()).Returns(mockList.Object);
			var firstUser = users.First();

			// Act
			var result = await sut.Handle(new GetUserByEmailQuery { Email = firstUser.EmailAddress }, CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(firstUser.EmailAddress, result.EmailAddress);
			mockRepository.Verify(x => x.GetAll(), Times.Once);
		}
	}
}