namespace BackendApi.Contracts.Comments
{
    public class CreateCommentsRequest
    {
        public int UserId { get; set; }
        public int BlockId { get; set; }
        public string TextComment { get; set; } = null!;
        public int CreatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
