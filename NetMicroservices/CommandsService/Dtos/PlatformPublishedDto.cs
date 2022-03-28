namespace CommandsService.Dtos
{
    /// <summary>
    /// Message Bus published DTO, we read from queue
    /// </summary>
    public class PlatformPublishedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Event { get; set; }
    }
}