using Microsoft.EntityFrameworkCore;

namespace WeatherForecastApp.Models.DbStorage
{
    public partial class WeatherContext : DbContext
    {
        public WeatherContext()
        {

        }

        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {

        }

        public virtual DbSet<SearchCity> SearchCities { get; set; }
        public virtual DbSet<DaysOfWeek> DaysOfWeeks { get; set; }
        public virtual DbSet<WeatherInfo> WeatherInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SearchCity>(entity =>
            {
                entity.ToTable("SearchCity");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CityName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CityName");

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<DaysOfWeek>(entity =>
            {
                entity.ToTable("DaysOfWeek");

                entity.Property(e => e.Id).HasColumnName("DayId");

                entity.Property(e => e.Day)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Day");

                entity.Property(e => e.LanguageDay)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<WeatherInfo>(entity =>
            {
                entity.ToTable("WeatherInfo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DayId).HasColumnName("dayId");

                entity.Property(e => e.TempMax)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Temp_max");

                entity.Property(e => e.TempMin)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Temp_min");

                entity.Property(e => e.Temperatura).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.WeathersInfo)
                    .HasForeignKey(d => d.DayId)
                    .HasConstraintName("FK__Weather__dayId__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
