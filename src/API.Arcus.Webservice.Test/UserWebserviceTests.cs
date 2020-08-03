using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Arcus.Infrastructure.Dto.User;
using Newtonsoft.Json;
using Xunit;

namespace API.Arcus.Webservice.Test
{
	public class UserWebserviceTests
	{
		[Fact]
		public async Task Get_ReturnValues()
		{
			// Arrange
			using var client = new TestClientProvider().Client;
			var userEmail = "christafford@gmail.com";

			// Act
			var response = await client.GetAsync($"/user?email={userEmail}");

			// Assert
			response.EnsureSuccessStatusCode();
			var stringData = response.Content.ReadAsStringAsync().Result;
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			var user = System.Text.Json.JsonSerializer.Deserialize<UserGetResponseDto>(stringData, options);

			Assert.Equal(userEmail, user.EmailAddress);
			Assert.Equal("Chris Colin Stafford", user.Name);
		}

		[Fact]
		public async Task Get_ReturnNotFound()
		{
			//Arrange
			using var client = new TestClientProvider().Client;
			var nonexistantEmail = "bob123@yahoo.com";

			//Act
			var response = await client.GetAsync($"/user?email={nonexistantEmail}");

			//Assert
			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
		}

		[Fact]
		public async Task Create_ShouldWork()
		{
			//Arrange
			using var client = new TestClientProvider().Client;

			var newUser = new UserPostRequestDto()
			{
				FirstName = "TestFirstName",
				MiddleName = "TestMiddleName",
				LastName = "TestLastName",
				EmailAddress = "TestEmailAddress@yahoo.com",
				PhoneNumber = "(555) 555-1234"
			};

			var stringContent = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");

			//Act
			var response = await client.PostAsync($"/user/", stringContent);

			//Assert
			response.EnsureSuccessStatusCode();
			var stringData = response.Content.ReadAsStringAsync().Result;
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var newId = System.Text.Json.JsonSerializer.Deserialize<UserPostResponseDto>(stringData, options);
			Assert.NotNull(newId);
		}

		[Fact]
		public async Task Create_ValidationError()
		{
			//Arrange
			using var client = new TestClientProvider().Client;

			var newUser = new UserPostRequestDto()
			{
				FirstName = "TestFirstName",
					MiddleName = "TestMiddleName",
					LastName = "TestLastName",
					EmailAddress = "TestEmailAddress~yahoo.com",
					PhoneNumber = "TestPhoneNumber123@phone.com"
			};

			var stringContent = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");

			//Act
			var response = await client.PostAsync($"/user/", stringContent);

			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
	}
}