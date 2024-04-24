using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingDALTest
{
    public class CartRepositoryTest
    {
        IRepository<int, Cart> repository;
        
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}