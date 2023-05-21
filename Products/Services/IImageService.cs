namespace Products.Services
{
    public interface IImageService
    {
        Task<ImageResponse> UploadImage(Guid productId, ProductImageDto productImageDto);
    }
}
