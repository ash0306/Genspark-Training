using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class ProductBLTest
    {
        IRepository<int, Product> repository;
        IProductService productService;
        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();
            Product product = new Product() { Name = "Nike Shoe", Price = 500, QuantityInHand = 10 };
            productService = new ProductBL(repository);
            productService.AddProduct(product);
        }


        [Test]
        public void GetByKeySuccessTest()
        {
            var product = productService.GetProductById(1);
            Assert.AreEqual(1, product.Id);
        }

        [Test]
        public void GetByKeyFailureTest()
        {
            Assert.Throws<NoProductWithGivenIdException>(() => productService.GetProductById(3));
        }

        [Test]
        public void AddSuccessTest()
        {
            Product product = new Product() { Id = 2, Name = "Pen", Price = 20, QuantityInHand = 4 };

            var addedItemId = productService.AddProduct(product);

            Assert.AreEqual(2, addedItemId.Result);
        }

        [Test]
        public void AddFailureTest()
        {
            Product product = null;

            Assert.Throws<NullReferenceException>(() => productService.AddProduct(product));
        }

        [Test]
        public void DeleteSuccessTest()
        {
            Product product = new Product() { Id = 3, Name = "Eraser", Price = 5, QuantityInHand = 3 };

            var addedItemId = productService.AddProduct(product);

            var deletedItem = productService.DeleteProduct(addedItemId.Result);
            
            Assert.IsNotNull(deletedItem);
        }

        [Test]
        public void DeleteFailureTest()
        {
            Assert.Throws<NoProductWithGivenIdException>(() => productService.DeleteProduct(1000));
        }

        [Test]
        public void GetAllSuccessTest()
        {
            var products = productService.GetAllProducts();

            Assert.IsNotNull(products.Result);
            Assert.IsNotEmpty(products.Result);
        }

        [Test]
        public void GetAllFailureTest()
        {
            Assert.Throws<NoProductWithGivenIdException>(()=> productService.DeleteProduct(10));
        }


        [Test]
        public void UpdateSuccessTest()
        {
            Product product = new Product() { Id = 4, Name = "Scale", Price = 15.00, QuantityInHand = 20 };

            var addedItemId = productService.AddProduct(product);

            product.Price = 10.00;

            var updatedItem = productService.UpdateProduct(product);

            Assert.AreEqual(updatedItem.Result.Price, 10.00);
        }


        [Test]
        public void UpdateFailureTest()
        {
            Product product = null;
            Assert.Throws<NullReferenceException>(() => productService.UpdateProduct(product));
        }
    }
}
