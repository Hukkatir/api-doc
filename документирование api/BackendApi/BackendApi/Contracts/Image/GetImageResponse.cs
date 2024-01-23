namespace BackendApi.Contracts.Image
{
    public class GetImageResponse
    {
        public int ImageId { get; set; }
        public int? BlockId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string? Note { get; set; }
    }
}
