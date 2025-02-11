namespace CloudHRMS.Models.ViewModels {
    public class PositionViewModel {
        public  string Id { get; set; }
        public  string Code { get; set; }
        public  string Description { get; set; }
        public  int Level { get; set; }
        override
            public string ToString()
        {
            return $"Code: {Code}, Description: {Description}, Level: {Level}";
        }
    }
}