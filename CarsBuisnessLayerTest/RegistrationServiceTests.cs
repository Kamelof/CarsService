using CarsBuisnessLayer.Interfaces;
using CarsBuisnessLayer.Services;
using CarsDataLayer.Interfaces;
using CarsDataLayer.Repositories;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CarsBuisnessLayerTest
{
    public class RegistrationServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IEmailRepository> _emailRepositoryMock;
        private Mock<ISmtpService> _smptServiceMock;
        private IRegistrationService _registrationService;
        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _emailRepositoryMock = new Mock<IEmailRepository>();
            _smptServiceMock = new Mock<ISmtpService>();
            _registrationService = new RegistrationService(
                _userRepositoryMock.Object,
                _emailRepositoryMock.Object,
                null,
                _smptServiceMock.Object);
        }

        [Test]
        public async Task ConfirmEmail_WhenMessageSendTheSameAsInBase_ShouldConfirmEmail()
        {
            var inputMail = "email.test@mail.com";
            var inputMessage = "confirMessage";
            _emailRepositoryMock.Setup(x => x
                .GetConfirmMessageAsync(inputMail))
                .ReturnsAsync(inputMessage)
                .Verifiable();
            _emailRepositoryMock.Setup(x => x
                .ConfirmEmailAsync(inputMail))
                .Verifiable();

            var actualResult = await _registrationService.ConfirmEmailAsync(inputMail, inputMessage);

            _emailRepositoryMock.Verify();
            Assert.True(actualResult);
        }

        [Test]
        public async Task ConfirmEmail_WhenMessageSendDifferFromBase_ShouldFailEmailConfirmation()
        {
            var inputMail = "email.test@mail.com";
            var inputMessage = "confirMessage";
            var badMessage = "bdConfMessage";
            _emailRepositoryMock.Setup(x => x
                .GetConfirmMessageAsync(inputMail))
                .ReturnsAsync(badMessage)
                .Verifiable();

            var actualResult = await _registrationService.ConfirmEmailAsync(inputMail, inputMessage);

            _emailRepositoryMock.Verify(x => x.ConfirmEmailAsync(It.IsAny<string>()), Times.Never);
            _emailRepositoryMock.Verify();
            Assert.False(actualResult);
        }
    }
}