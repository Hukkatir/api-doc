namespace BackendApi.Contracts.Video
{
    public class GetVideoResponse
    {
        public int VideoId { get; set; }
        public int? BlockId { get; set; }
        public string VideoUrl { get; set; } = null!;
        public string? Note { get; set; }
    }
}
