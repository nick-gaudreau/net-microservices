namespace PlatformService.Dtos
{
    /// <summary>
    /// Message Bus publish DTO
    /// </summary>
    public class PlatformPublishedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Event { get; set; }
    }
}