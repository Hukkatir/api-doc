namespace BackendApi.Contracts.Image
{
    public class CreateImageRequest
    {
        public int BlockId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string? Note { get; set; }
    }
}
