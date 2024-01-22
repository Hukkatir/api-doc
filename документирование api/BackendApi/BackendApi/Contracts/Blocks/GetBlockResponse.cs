namespace BackendApi.Contracts.Blocks
{
    public class GetBlockResponse
    {
        public int BlockId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string BlockName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string TextBlock { get; set; } = null!;
        public int IndexBlock { get; set; }
        public int? BlockTypeId { get; set; }
        public int CreatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? FeedbackId { get; set; }
    }
}
