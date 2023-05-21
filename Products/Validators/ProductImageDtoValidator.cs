public class ProductImageDtoValidator : BaseDtoValidator<ProductImageDto>
{
    public ProductImageDtoValidator()
    {
        RuleFor(c => c.ImageFile).NotEmpty().WithMessage("Image is Required").NotNull().WithMessage("Image must be not null");

    }
}