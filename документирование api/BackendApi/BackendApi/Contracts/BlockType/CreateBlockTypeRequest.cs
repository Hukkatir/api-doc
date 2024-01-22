namespace BackendApi.Contracts.BlockType
{
    public class CreateBlockTypeRequest
    {
        public int? BlockId { get; set; }
        public int? TextTypeId { get; set; }
        public int? VideoId { get; set; }
        public int? ImageId { get; set; }

    }
}
