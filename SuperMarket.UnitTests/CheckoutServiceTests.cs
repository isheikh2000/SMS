using SuperMarket.Application.Services;

namespace SuperMarket.UnitTests;

public class CheckoutServiceTests
{
    [SetUp]
    public void Setup()
    {        
    }

    [Test]
    public void Scan_SingleItem_ReturnRegularPrice()
    {
        //Arrange
        var checkoutService = new CheckoutService();

        //Act
        checkoutService.Scan("A");        
        var result = checkoutService.GetTotalPrice();

        //Assert
        Assert.AreEqual(50, result);
    }
}
