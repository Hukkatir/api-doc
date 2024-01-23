namespace BackendApi.Contracts.Feedback
{
    public class GetFeedbackResponse
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public int? BlockId { get; set; }
        public int? CommentId { get; set; }
        public bool? Likes { get; set; }
        public int? LikesCount { get; set; }
        public int? DislikesCount { get; set; }
    }
}
