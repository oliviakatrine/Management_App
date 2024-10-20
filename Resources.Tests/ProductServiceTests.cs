using Resources.Enums;
using Resources.Models;
using Resources.Services;

namespace Resources.Tests;

public class ProductServiceTests
{
    [Fact]
    public void AddToList_ShouldReturnSuccess_WhenProductAddedToList()
    {
        // Arrange
        Product product = new Product { Title = "Vampires & Werewolves", Genre = "Fiction", Price = "199 kr" };
        ProductService productService = new ProductService();

        // Act
        ResultStatus result = productService.AddToList(product);
        var productList = productService.GetAllProducts();

        // Assert
        Assert.Equal(ResultStatus.Success, result);
        Assert.Single(productList);

    }
}
