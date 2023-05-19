using Microsoft.AspNetCore.Http;

namespace Products.Dtos
{
    public class ProductImageDto : BaseDto
    {
        public IFormFile ImageFile { get; set; }
    }
}
