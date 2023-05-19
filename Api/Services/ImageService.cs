using Products.Dtos;
using Products.Services;

namespace Api.Services
{
    public class ImageService : IImageService

    {
        private readonly IProductUnitOfWork _unitOfWork;

        public ImageService(IProductUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ImageResponse> UploadImage(Guid productId, ProductImageDto productImageDto)
        {
            var product = await _unitOfWork.ReadByIdAsync(productId);
            if (productImageDto == null || productImageDto.ImageFile == null || productImageDto.ImageFile.Length == 0)
            {
                return new ImageResponse
                {
                    Status = "Failed",
                    Message = "Invalid image uploaded"
                };
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(productImageDto.ImageFile.FileName);

            string uploadPath = Path.Combine("wwwroot", $"uploads/products/images/{productId}");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await productImageDto.ImageFile.CopyToAsync(stream);
            }

            product.Image = $"/uploads/products/images/{productId}/{fileName}";
            await _unitOfWork.UpdateAsync(product);

            return new ImageResponse
            {
                Status = $"Success - {product.Image}",
                Message = "image uploaded Successfully"
            };
        }
    }
}
