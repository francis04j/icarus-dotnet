using System;
using Domain.Common;

namespace Domain.Entities
{
    public class WeatherForecastt : AuditableEntity
    {
        public Guid WeatherForecasttId { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        //TODO: move to view model
        // public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
