public class ProductForUpdateDtoValidator : BaseDtoValidator<ProductForUpdateDto>
{
    public ProductForUpdateDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is Required").NotNull().WithMessage("Name can not be null").MinimumLength(8);
        RuleFor(c => c.Description).NotEmpty().WithMessage("Description is Required").NotNull().WithMessage("Description can not be null").MinimumLength(20);
        RuleFor(c => c.Price).NotEmpty().WithMessage("Price is Required").NotNull().WithMessage("Price can not be null").GreaterThan(0);
    }
}