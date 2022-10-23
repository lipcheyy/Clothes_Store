﻿using Clothes_Store.Controllers;
using DbAccessLibrary.DbAccess;
using DbAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests
{
    public class CartControllerTests
    {
        [Test]
        public async Task AddToCart_Work()
        {
            //Arrange
            var ctx  = GetClothesStoreDbContext();
            var controller = new CartController(ctx);

            //first is add clothes to db
            var bytes = Encoding.UTF8.GetBytes("This is an img file");
            Clothes clothes = new Clothes()
            {
                Id = 1,
               Name = "123",
               SellerId = 3,
               Color = Colors.White,
               Price = 1900,
               TypeOfClothes = TypesOfClothes.Boots,
               PreviewImage = bytes,
            };
            ctx.Clothes.Add(clothes); 
            ctx.SaveChanges();
            CreateMockUserObject(ref controller);

            //Act
            await controller.AddToCart(clothes.Id);
            var itemResult = ctx.Carts.SingleOrDefault(); //get item from db for assert

            //Asset
            Assert.AreEqual(clothes.Id, itemResult.ClothesId); 

        }


        [Test]
        public async Task DeleteFromCart_Work()
        {
            //Arrange
            var ctx = GetClothesStoreDbContext();
            var controller = new CartController(ctx);

            //first is add cart to db
            var cart = new Cart()
            {
                Id = 1,
                ClothesId = 90,
                ApplicationUserId = "UserId", //UserId is sets on Claim(ClaimTypes.NameIdentifier, "UserId"),!!
                Date = DateTime.Now,
                Size = Size.S,
                Quantity = 2,
                IsOrderFinished = false,
            };
            ctx.Carts.Add(cart);
            ctx.SaveChanges();

            CreateMockUserObject(ref controller);
            //Act

            await controller.DeleteFromCart(cart.ClothesId);
            var itemResult = ctx.Carts.Where(x=>x.Id == cart.Id).FirstOrDefault(); //get item from db for assert

            //Asset
            Assert.IsNull(itemResult);

        }

        private ClothesStoreDbContext GetClothesStoreDbContext()
        {
            var options = new DbContextOptionsBuilder<ClothesStoreDbContext>()
            .UseInMemoryDatabase(databaseName: "database").Options;
            return new ClothesStoreDbContext(options);
        }

        private void CreateMockUserObject(ref CartController controller)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "UserId"),
                                        new Claim(ClaimTypes.Name, "gunnar@somecompany.com")
                                   }, "TestAuthentication"));
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
        }
    }
}
