using Entities;
using Repos;
using FluentAssertions;
namespace ServiceTests;

public class GetServciceTests
{


    [Fact]
    public async Task GetAllAsync_ShouldReturnProducts()
    {
        // Arrange
        var repo = new ProductRepo();

        // Act
        var products = await repo.GetAllAsync();

        // Assert
        products.Should().ContainEquivalentOf(new Product("Iphone", 14999));
    }
    

}