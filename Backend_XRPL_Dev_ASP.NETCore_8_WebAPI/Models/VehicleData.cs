namespace Backend_XRPL_Dev_ASP.NETCore_8_WebAPI.Models
{
    public class VehicleData
    {
        public int? Id { get; set; }
        public string? VIN { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public int MileageTrip { get; set; }
        public int MileageSum { get; set; }
    }
}
