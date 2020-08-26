using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class WeatherForecasttConfiguration : IEntityTypeConfiguration<WeatherForecastt>
    {
        public void Configure(EntityTypeBuilder<WeatherForecastt> builder)
        {
            builder.Property(e => e.WeatherForecasttId).HasColumnName("WeatherForecastID");

            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.Property(e => e.Summary).HasMaxLength(1024);

            builder.Property(e => e.TemperatureC).HasColumnName("TemperatureC");
        }
    }
}