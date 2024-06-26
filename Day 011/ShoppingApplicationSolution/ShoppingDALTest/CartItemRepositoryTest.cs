﻿using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class CartItemRepositoryTest
    {
        IRepository<int, CartItem> repository;
        [SetUp]
        public void Setup()
        {
            repository = new CartItemRepository();
        }

        [Test]
        public void AddCartItemSuccessTest()
        {
            Product product = new Product() { Id = 1, Price = 1000, Name = "Pencil", QuantityInHand = 4 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 0.15, Price = 1000, PriceExpiryDate = DateTime.Now, ProductId = 1, Quantity = 1, Product = product };
            //Action
            var result = repository.Add(cartItem);
            //Assert
            Assert.AreEqual(1, result.Result.ProductId);
        }

        [Test]
        public void AddCartItemFailureTest()
        {
            Product product = new Product() { Id = 1, Price = 1000, Name = "Pencil", QuantityInHand = 4 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 0.15, Price = 1000, PriceExpiryDate = DateTime.Now, ProductId = 2, Quantity = 1, Product = product };
            //Action
            var result = repository.Add(cartItem);
            //Assert
            Assert.AreNotEqual(1, result.Result.ProductId);
        }

        [Test]
        public void GetByKeySuccessTest()
        {
            // Arrange
            Product product = new Product() { Id = 1, Price = 1000, Name = "Pencil", QuantityInHand = 4 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 0.15, Price = 1000, PriceExpiryDate = DateTime.Now, ProductId = 1, Quantity = 1, Product = product };
            repository.Add(cartItem);

            // Action
            var result = repository.GetByKey(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Result.ProductId);
        }

        [Test]
        public void GetByKeyFailureTest()
        {
            Assert.Throws<NoCartItemWithGivenIdException>(() => repository.GetByKey(1));
            // Assert
        }


        [Test]
        public void UpdateSuccessTest()
        {
            // Arrange
            Product product = new Product() { Id = 1, Price = 1000, Name = "Pencil", QuantityInHand = 4 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 0.15, Price = 1000, PriceExpiryDate = DateTime.Now, ProductId = 1, Quantity = 1, Product = product };
            repository.Add(cartItem);

            // Update the cart item
            cartItem.Quantity = 2;

            // Action
            var updatedCartItem = repository.Update(cartItem);

            // Assert
            Assert.IsNotNull(updatedCartItem);
            Assert.AreEqual(2, updatedCartItem.Result.Quantity);
        }

        [Test]
        public void UpdateFailureTest()
        {
            // Arrange
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 0.15, Price = 1000, PriceExpiryDate = DateTime.Now, ProductId = 1, Quantity = 1 };

            // Action
            Assert.Throws<NoCartItemWithGivenIdException>(() => repository.Update(cartItem));
        }

        [Test]
        public void DeleteSuccessTest()
        {
            // Arrange
            Product product = new Product() { Id = 1, Price = 1000, Name = "Pencil", QuantityInHand = 4 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 0.15, Price = 1000, PriceExpiryDate = DateTime.Now, ProductId = 1, Quantity = 1, Product = product };
            repository.Add(cartItem);

            // Action
            var deletedCartItem = repository.Delete(1);

            // Assert
            Assert.IsNotNull(deletedCartItem);
        }

        [Test]
        public void DeleteFailureTest()
        {
            // Assert
            Assert.Throws<NoCartItemWithGivenIdException>(() => repository.Delete(1));
        }

        [Test]
        public void GetAllSuccessTest()
        {
            // Arrange
            Product product1 = new Product() { Id = 1, Price = 1000, Name = "Pencil", QuantityInHand = 4 };
            Product product2 = new Product() { Id = 2, Price = 2000, Name = "Pen", QuantityInHand = 5 };
            CartItem cartItem1 = new CartItem() { CartId = 1, Discount = 0.15, Price = 1000, PriceExpiryDate = DateTime.Now, ProductId = 1, Quantity = 1, Product = product1 };
            CartItem cartItem2 = new CartItem() { CartId = 1, Discount = 0.20, Price = 2000, PriceExpiryDate = DateTime.Now, ProductId = 2, Quantity = 2, Product = product2 };
            repository.Add(cartItem1);
            repository.Add(cartItem2);

            // Action
            var cartItems = repository.GetAll();

            // Assert
            Assert.IsNotNull(cartItems);
            Assert.AreEqual(2, cartItems.Result.Count);
        }

        [Test]
        public void GetAllFailureTest()
        {
            // Action
            var cartItems = repository.GetAll();

            // Assert
            Assert.IsEmpty(cartItems.Result);
        }
    }
}
