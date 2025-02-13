﻿using SuperMarket.Application.Services;
using SuperMarket.Domain.Interfaces;
using SuperMarket.UnitTests.TestData;

namespace SuperMarket.UnitTests;

public class CheckoutServiceTests
{
    private IProductPriceRepository _priceRepository;

    [SetUp]
    public void Setup()
    {
        _priceRepository = new ProductPriceRepositoryTestData();
    }

    [Test]
    public void Scan_SingleItem1_ReturnRegularPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository);

        //Act
        checkoutService.Scan("A");        
        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(50, result);
    }

    [Test]
    public void Scan_SingleItem2_ReturnRegularPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository);

        //Act
        checkoutService.Scan("D");
        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(15, result);
    }
}
