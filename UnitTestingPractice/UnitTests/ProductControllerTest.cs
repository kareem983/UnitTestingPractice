using Core.Abstractions;
using Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingPractice.Controllers;

namespace UnitTests
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductService> productService;

        public ProductControllerTest()
        {
            productService = new Mock<IProductService>();
        }


        [Fact]
        public void GetProductList_ProductList()
        {
            // arrange
            var productList = GetProductsData().Result;
            
            productService.Setup(x => x.GetProductList().Result)
                .Returns(productList);
            
            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.GetProductList().Result;

            //assert
            Assert.NotNull(productResult.Data);
            Assert.Equal(200, productResult.StatusCode);
            Assert.Equal(productList.ToString(), productResult.Data.ToString());
            Assert.True(productList.Equals(productResult.Data));
        }


        [Fact]
        public void GetProductByID_Product()
        {
            //arrange
            var productList = GetProductsData().Result;

            productService.Setup(x => x.GetProductById(2).Result)
                .Returns(productList[1]);

            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.GetProductById(2).Result;

            //assert
            Assert.NotNull(productResult.Data);
            Assert.Equal(productList[1].ProductId, (productResult.Data as Product).ProductId);
            Assert.True(productList[1].ProductId == (productResult.Data as Product).ProductId);
        }


        [Theory]
        [InlineData("IPhone")]
        public void CheckProductExistOrNotByProductName_Product(string productName)
        {
            //arrange
            var productList = GetProductsData().Result;

            productService.Setup(x => x.GetProductList().Result)
                .Returns(productList);

            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.GetProductList().Result.Data as List<Product>;
            var expectedProductName = productResult.ToList()[0].ProductName;

            //assert
            Assert.Equal(productName, expectedProductName);
        }


        [Fact]
        public void AddProduct_Product()
        {
            //arrange
            Product microwaveProduct = new Product()
            {
                ProductId = 4,
                ProductName = "Microwave",
                ProductDescription = "Microwave plus",
                ProductPrice = 2000,
                ProductStock = 3
            };

            productService.Setup(x => x.AddProduct(microwaveProduct).Result)
                .Returns(microwaveProduct);

            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.AddProduct(microwaveProduct).Result.Data as Product;

            //assert
            Assert.NotNull(productResult);
            Assert.Equal(microwaveProduct.ProductId, productResult.ProductId);
            Assert.True(microwaveProduct.ProductId == productResult.ProductId);
        }


        [Fact]
        public void UpdateProduct_Product()
        {
            //arrange
            var productList = GetProductsData().Result;
            Product LaptopProduct = new Product()
            {
                ProductId = 2,
                ProductName = "Laptop",
                ProductDescription = "HP Pavilion",
                ProductPrice = 50000,
                ProductStock = 20
            };

            productService.Setup(x => x.UpdateProduct(LaptopProduct).Result)
                .Returns(LaptopProduct);

            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.UpdateProduct(LaptopProduct).Result.Data as Product;

            //assert
            Assert.NotNull(productResult);
            Assert.NotEqual(productResult.ProductPrice, productList[1].ProductPrice);
            Assert.True(LaptopProduct.ProductId == productResult.ProductId);
        }

        [Fact]
        public void DeleteProduct_Product()
        {
            //arrange
            productService.Setup(x => x.DeleteProduct(2).Result)
                .Returns(true);

            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.DeleteProduct(2).Result.Data;

            //assert
            Assert.NotNull(productResult);
            Assert.Equal(productResult, true);
        }


        [Fact]
        public void DeleteProduct2_Product()
        {
            //arrange
            productService.Setup(x => x.DeleteProduct(5).Result)
                .Returns(false);

            var productController = new ProductController(productService.Object);

            //act
            var productResult = productController.DeleteProduct(5).Result.Data;

            //assert
            Assert.Null(productResult);
            Assert.Equal(productResult, null);
        }

        private async Task<List<Product>> GetProductsData()
        {
            List<Product> productsData = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "IPhone",
                    ProductDescription = "IPhone 12",
                    ProductPrice = 55000,
                    ProductStock = 10
                },
                 new Product
                {
                    ProductId = 2,
                    ProductName = "Laptop",
                    ProductDescription = "HP Pavilion",
                    ProductPrice = 100000,
                    ProductStock = 20
                },
                 new Product
                {
                    ProductId = 3,
                    ProductName = "TV",
                    ProductDescription = "Samsung Smart TV",
                    ProductPrice = 35000,
                    ProductStock = 30
                },
            };

            return productsData;
        }

    }
}
