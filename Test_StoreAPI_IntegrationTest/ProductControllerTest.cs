using FluentAssertions;
using Newtonsoft.Json;
using StoreAPI.Contracts.V1;
using StoreAPI.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test_StoreAPI_IntegrationTest
{
    public class ProductControllerTest: IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithProductsShouldNotBeEmpty()
        {
            //Arrange
          await AuthenticateAsync();
            //Act
            var response = await _client.GetAsync(ApiRoutes.Product.GetAll);
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<ProductModel>>()).Should().NotBeEmpty();
        }
        [Fact]
        public async Task Get_ReturnsPost_WhenPostExistsInTheDatabase()
        {
            // Arrange
              await AuthenticateAsync();

            var createdProduct = await CreateProductAsync(new ProductModel {
                ProductID = "0",
                ProductName = "Test Product Name",
                ProductDescription = "Test Product Description",
                ImagePath = "images/kitchenware-3.jpg",
                CategoryID = "1",
                ProductPrice = 200 }); 

            // Act
   
            var response = await _client.GetAsync(ApiRoutes.Product.Get.Replace("{ProductID}", createdProduct.ProductID.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedPost = await response.Content.ReadAsAsync<ProductModel>();
            returnedPost.ProductID.Should().Be(createdProduct.ProductID);
            returnedPost.ProductName.Should().Be("Test Product Name");
        }
    }
}
