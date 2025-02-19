using SuperMarket.Application.Services;
using SuperMarket.Domain.Exceptions;
using SuperMarket.Domain.Interfaces;
using SuperMarket.Domain.Rules;
using SuperMarket.UnitTests.TestData;

namespace SuperMarket.UnitTests;

public class CheckoutServiceTests
{
    private IProductRepository _priceRepository;

    private IPricingStrategyFactory _factory;


    [SetUp]
    public void Setup()
    {
        _priceRepository = new ProductRepositoryTestData();

        _factory = new PricingStrategyFactory(); 
    }

    [Test]
    public void Scan_InvalidItem_ThrowInvalidProductException()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository, _factory);

        //Act   
        var exception = Assert.Throws<InvalidProductException>(() => checkoutService.Scan("Z"));

        //Assert
        Assert.AreEqual("Invalid Product: Z", exception.Message);
    }


    [Test]
    public void Scan_ZeroItem_ReturnZeroPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository, _factory);

        //Act        
        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Scan_SingleItem1_ReturnRegularPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository, _factory);

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
        var checkoutService = new CheckoutService(_priceRepository, _factory);

        //Act
        checkoutService.Scan("D");
        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(15, result);
    }

    [Test]
    public void Scan_MultipleItems1_ReturnRegularPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository, _factory);

        //Act
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        checkoutService.Scan("B");
        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(130, result);
    }

    [Test]
    public void Scan_MultipleItems2_ReturnRegularPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository, _factory);

        //Act
        checkoutService.Scan("C");
        checkoutService.Scan("D");
        checkoutService.Scan("C");
        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(55, result);
    }

    [Test]
    public void Scan_MultipleItems1_ReturnSpecialPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository, _factory);

        //Act
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(130, result);
    }

    [Test]
    public void Scan_MultipleItems2_ReturnSpecialPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository, _factory);

        //Act
        checkoutService.Scan("B");
        checkoutService.Scan("B");        
        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(45, result);
    }

    [Test]
    public void Scan_MultipleItems1_DifferentTypes_ReturnRegularAndSpecialPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository, _factory);

        //Act
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        checkoutService.Scan("B");
        checkoutService.Scan("B");
        checkoutService.Scan("C");
        checkoutService.Scan("D");
        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(210, result);
    }

    [Test]
    public void Scan_MultipleItems2_DifferentTypes_ReturnRegularAndSpecialPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository, _factory);

        //Act
        checkoutService.Scan("C");
        checkoutService.Scan("D");
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        checkoutService.Scan("B");
        checkoutService.Scan("B");

        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(180, result);
    }

    [Test]
    public void Scan_MultipleItems_Discounts_ReturnSpecialPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService(_priceRepository, _factory);

        //Act
        checkoutService.Scan("B");
        checkoutService.Scan("B");
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        checkoutService.Scan("A");
        checkoutService.Scan("B");
        checkoutService.Scan("B");

        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(350, result);
    }


}
