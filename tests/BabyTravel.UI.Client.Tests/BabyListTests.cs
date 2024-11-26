using BabyTravel.Api.Client;
using BabyTravel.UI.Client.Components.Baby;
using BabyTravel.UI.Client.Models.Baby;
using Bunit;
using Bunit.TestDoubles;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Radzen;
using Radzen.Blazor;
using System.Diagnostics.Metrics;

namespace BabyTravel.UI.Client.Tests
{
    public class BabyListTests : TestContext
    {
        private readonly Mock<IBabyClient> _babyClientMock;
        private readonly Mock<ICalculateClient> _calculateClientMock;
        private readonly List<BabyResponse> _babies = new List<BabyResponse>()
            {
                new()
                {
                    Id = 1,
                    Name = "A",
                    BabyBirthday = DateTime.Today.AddMonths(-1)
                },
                new()
                {
                    Id = 2,
                    Name = "B",
                    BabyBirthday = DateTime.Today.AddMonths(-2)
                },
                new()
                {
                    Id= 3,
                    Name = "C",
                    BabyBirthday = DateTime.Today.AddMonths(-3)
                }
            };

        public BabyListTests()
        {
            _babyClientMock = new Mock<IBabyClient>();
            _babyClientMock.Setup(x => x.GetAllAsync()).ReturnsAsync(_babies);
            Services.AddScoped(_ => _babyClientMock.Object);

            _calculateClientMock = new Mock<ICalculateClient>();
            Services.AddScoped(x => _calculateClientMock.Object);

            Services.AddScoped<DialogService>();

            var authContext = this.AddTestAuthorization();
            authContext.SetAuthorized("test");
        }

        [Fact]
        public void OpensBabyDialogOnAdd()
        {

        }

        [Fact]
        public async Task OpensBabyDialogOnEdit()
        {
            // Arrange
            var babyToEdit = _babies[0];

            var component = RenderComponent<BabyList>();

            // Act
            var babyCards = component.FindComponents<RadzenCard>();
            var babyCard = babyCards.First(x => x.Find("#baby-name").TextContent == babyToEdit.Name);
            await babyCard.Find("#edit-baby").ClickAsync(new Microsoft.AspNetCore.Components.Web.MouseEventArgs());

            // Assert
            var babyDialog = component.Find("#baby-dialog");
        }

        [Fact]
        public void DeletesBaby()
        {
            // Arrange
            var babyToDelete = _babies[0];

            var component = RenderComponent<BabyList>();

            // Act
            var babyCards = component.FindComponents<RadzenCard>();
            var babyCard = babyCards.First(x => x.Find("#baby-name").TextContent == babyToDelete.Name);
            babyCard.Find("#delete-baby").Click();

            // Assert
            _babyClientMock.Verify(x => x.DeleteAsync(babyToDelete.Id), Times.Once);
        }

        [Fact]
        public void DisplaysAllBabies()
        {
            // Arrange
            var component = RenderComponent<BabyList>();

            // Act
            var babyCards = component.FindComponents<RadzenCard>();

            // Assert
            babyCards.Should().HaveCount(_babies.Count);
        }

        [Fact]
        public void OrdersBabiesByAge()
        {
            // Arrange
            var component = RenderComponent<BabyList>();

            // Act
            var babyCards = component.FindComponents<RadzenCard>();

            // Assert
            var expectedBabyOrder =
                _babies
                .OrderBy(b => b.BabyBirthday)
                .Select(b => b.Name);
           
            babyCards
                .Select(c =>
                {
                    var textNode = c.Find("#baby-name");

                    return textNode.TextContent;
                })
                .Should()
                .BeEquivalentTo(expectedBabyOrder);
        }
    }
}