namespace BackendApi.Contracts.Feedback
{
    public class CreateFeedbackRequest
    {
        public int UserId { get; set; }
        public int? BlockId { get; set; }
        public int? CommentId { get; set; }
        public bool? Likes { get; set; }
        public int? LikesCount { get; set; }
        public int? DislikesCount { get; set; }
    }
}
