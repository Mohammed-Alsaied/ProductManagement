public class ProductForCreateDtoValidator : BaseDtoValidator<ProductForCreateDto>
{
    public ProductForCreateDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().MinimumLength(8);
        RuleFor(c => c.Description).NotEmpty().NotNull().MinimumLength(20);
        RuleFor(c => c.Price).NotEmpty().NotNull().GreaterThan(0);
    }
}