namespace CloudHRMS.Models.ViewModels
{
    public class PositionViewModel
    {
        public required string Id { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
        public required int Level { get; set; }
    }
}
