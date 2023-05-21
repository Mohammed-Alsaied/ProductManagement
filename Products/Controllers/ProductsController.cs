[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class ProductsController : BaseController<Product, ProductForCreateDto, ProductForReadDto, ProductForUpdateDto>
{
    private readonly IImageService _imageService;
    private readonly IWebHostEnvironment _environment;
    public ProductsController(IProductUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<ProductForCreateDto> validatorForCreateDto,
        IValidator<ProductForUpdateDto> validatorForUpdateDto,
        ILogger<BaseController<Product, ProductForCreateDto, ProductForReadDto, ProductForUpdateDto>> logger,
        IImageService imageService,
        IWebHostEnvironment environment)
        : base(unitOfWork, mapper, validatorForCreateDto, validatorForUpdateDto, logger)
    {
        _imageService = imageService;
        _environment = environment;
    }
    [MustHavePermission(Action.View, Resource.Products)]
    public override Task<IEnumerable<ProductForReadDto>> Get()
    {
        return base.Get();
    }
    [MustHavePermission(Action.View, Resource.Products)]
    public override Task<IActionResult> Get(Guid id)
    {
        return base.Get(id);
    }

    [MustHavePermission(Action.Delete, Resource.Products)]
    public override async Task Delete(Guid id)
    {
        var product = await _unitOfWork.ReadByIdAsync(id);
        if (!string.IsNullOrEmpty(product.Image))
        {
            string wwwrootPath = Path.Combine("..", "Api", "wwwroot");

            string imagePath = Path.Combine(wwwrootPath, product.Image);

            // Delete the image file from the file system
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }
        await _unitOfWork.DeleteAsync(id);
    }
    [MustHavePermission(Action.Create, Resource.Products)]
    public override Task<IActionResult> Post([FromForm] ProductForCreateDto entityDto)
    {
        return base.Post(entityDto);
    }
    [MustHavePermission(Action.Upload, Resource.Products)]
    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImage([FromForm] Guid productId, [FromForm] ProductImageDto productImageDto)
    {
        var result = await _imageService.UploadImage(productId, productImageDto);
        return Ok(result);
    }
    [MustHavePermission(Action.Update, Resource.Products)]
    public override Task<IActionResult> Put(Guid id, [FromForm] ProductForUpdateDto productForUpdateDto)
    {
        return base.Put(id, productForUpdateDto);
    }
}