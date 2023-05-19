public class ProductForUpdateDto : BaseDto
{
    [JsonIgnore]
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? Image { get; set; }
}