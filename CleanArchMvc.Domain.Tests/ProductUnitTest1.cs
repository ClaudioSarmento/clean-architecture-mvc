using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact(DisplayName = "Create Product With Valid State")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1,"Product Name", "Product description", 10.99m,5, "https://static.devcloud.io/assets/images/v2/placeholder-640x480.png");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product Negative Id DomainExceptionInvalidId")]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1,"Product Name", "Product description", 10.99m, 5, "https://static.devcloud.io/assets/images/v2/placeholder-640x480.png");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Product ShortNameValue DomainExceptionShortName")]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Pr", "Product description", 10.99m, 5, 
            "https://static.devcloud.io/assets/images/v2/placeholder-640x480.png");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    [Fact(DisplayName = "Create Product LongImageName DomainExceptionLongImageName")]
    public void CreateProduct_LongImageName_DomainExceptionLongImageName()
    {
        Action action = () => new Product(1, "Product Name", "Product description", 10.99m, 5,
            "https://www.example.com/long-url-test-for-demonstration-purposes-only/validate-length0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789ExtraPaddingToReachTheLimitNow!https://www.example.com/long-url-test-for-demonstration-purposes-only/validate-length?data=abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789ExtraPaddingToReachTheLimitNow!");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image name, too long, maximum 250 characters");
    }

    [Fact(DisplayName = "Create Product WhithNullImageName NoDomainExcception")]
    public void CreateProduct_WhithNullImageName_NoDomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product description", 10.99m, 5, null);
        action.Should()
           .NotThrow<DomainExceptionValidation>();
    }

    [Theory(DisplayName = "Create Product InvalidStockValue ExceptionDomainNegativeValue")]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
    {
        Action action = () => new Product(1, "Product Name", "Product description", 10.99m, value, "https://static.devcloud.io/assets/images/v2/placeholder-640x480.png");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }


    [Fact(DisplayName = "Create Product MissingNameValue DomainExceptionRequiredName")]
    public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Product(1, "", "Product description", 10.99m, 5, "https://static.devcloud.io/assets/images/v2/placeholder-640x480.png");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Product WithNullNameValue DomainExceptionInvalidName")]
    public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Product(1, null, "Product description", 10.99m, 5, "https://static.devcloud.io/assets/images/v2/placeholder-640x480.png");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

}
