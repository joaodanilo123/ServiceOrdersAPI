using Microsoft.Extensions.Configuration;
using ServiceOrdersManagement.Application.DTOs;
using ServiceOrdersManagement.Application.Services;

namespace ServiceOrdersManagement.Tests
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthServiceTests()
        {
            _configuration = TestConfiguration.BuildConfiguration();
            _authService = new AuthService(_configuration);
        }

        [Fact]
        public void Authenticate_ValidCredential_ReturnToken()
        {
            var loginDto = new LoginDTO() { Username = "admin", Password = "123" };
            var token = _authService.Login(loginDto);

            Assert.NotNull(token);
            Assert.IsType<TokenDTO>(token);
            Assert.IsType<string>(token.Token);
        }

    }
}