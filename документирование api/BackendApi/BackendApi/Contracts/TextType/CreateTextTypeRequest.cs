namespace BackendApi.Contracts.TextType
{
    public class CreateTextTypeRequest
    {
        public int? BlockId { get; set; }
        public string Content { get; set; } = null!;
        public bool? Bold { get; set; }
        public bool? Italic { get; set; }
        public bool? Strikethrough { get; set; }
        public bool? Underline { get; set; }
        public bool? Code { get; set; }
        public string Color { get; set; } = null!;
        public string? Href { get; set; }
    }
}
