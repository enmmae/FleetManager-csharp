
namespace Eatech.FleetManager.ApplicationCore.Entities
{
    public class CarDto
    {
        public string Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Registration { get; set; }

        public int ModelYear { get; set; }

        public string InspectionDate { get; set; }

        public int EngineSize { get; set; }

        public int EnginePower { get; set; }

        public CarDto(Car car)
        {
            Id = car.Id;
            Make = car.Make;
            Model = car.Model;
            Registration = car.Registration;
            ModelYear = car.ModelYear;
            InspectionDate = car.InspectionDate;
            EngineSize = car.EngineSize;
            EnginePower = car.EnginePower;
        }
    }
}