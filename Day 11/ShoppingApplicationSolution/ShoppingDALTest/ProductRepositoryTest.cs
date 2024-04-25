using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class ProductRepositoryTest
    {
        IRepository<int, Product> repository;

        [SetUp]
        public void SetUp()
        {
            repository = new ProductRepository();
            Product product = new Product() { Id = 1, Name = "Pen", Price = 10};
            repository.Add(product);
        }

        // ADD

        [Test]
        public void AddSuccessTest()
        {
            Product product = new Product() { Id = 2, Name = "Pencil", Price = 20 };
            var result = repository.Add(product);

            Assert.AreEqual(product.Id, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            Product product = null;
            var result = repository.Add(product);
            Assert.IsNull(result);
        }

        //UPDATE
        [Test]
        public void UpdateSuccessTest()
        {
            Product product = new Product() { Id = 1, Price = 20, Name = "Pen"};
            var result = repository.Update(product);
            Assert.AreEqual(product.Id, result.Id);
        }

        [Test]
        public void UpdateFailureTest()
        {
            Product product = new Product() { Id = 1, Price = 20, Name = "Pen" };
            repository.Delete(1);

            Assert.Throws<NoProductWithGivenIdException>(() => repository.Update(product));
        }

        // GET ALL
        [Test]
        public void GetAllSuccessTest()
        {
            var result = repository.GetAll();
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllFailTest()
        {
            repository.Delete(1);
            var result = repository.GetAll();
            Assert.AreEqual(result.Count, 0);
        }


        // GET BY ID

        [Test]
        public void GetByIdSuccessTest()
        {
            var result = repository.GetByKey(1);

            Assert.AreEqual(result.Id, 1);
        }

        [Test]
        public void GetByIdFailureTest()
        {
            Assert.Throws<NoProductWithGivenIdException>(() => repository.GetByKey(222));
        }

        //DELETE

        [Test]
        public void DeleteSuccessTest()
        {
            var result = repository.Delete(1);

            Assert.AreEqual(result.Id, 1);
        }

        [Test]
        public void DeleteFailTest()
        {
            Assert.Throws<NoProductWithGivenIdException>(() => repository.Delete(200));
        }
    }
}
