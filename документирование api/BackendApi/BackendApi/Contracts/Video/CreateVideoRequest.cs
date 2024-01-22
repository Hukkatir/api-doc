namespace BackendApi.Contracts.Video
{
    public class CreateVideoRequest
    {
        public int? BlockId { get; set; }
        public string VideoUrl { get; set; } = null!;
        public string? Note { get; set; }
    }
}
