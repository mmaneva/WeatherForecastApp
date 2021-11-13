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

        public virtual DbSet<DaysOfWeek> DaysOfWeeks { get; set; }
        public virtual DbSet<WeatherInfo> WeatherInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<DaysOfWeek>(entity =>
            {
                entity.ToTable("DaysOfWeek");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Day)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Day");

                entity.Property(e => e.LanguageDay)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasData(
                    new DaysOfWeek { Id = 1, Day = "Monday", LanguageDay = "en", OrderNumber = 1 },
                    new DaysOfWeek { Id = 2, Day = "Понеделник", LanguageDay = "mk", OrderNumber = 1 },
                    new DaysOfWeek { Id = 3, Day = "Tuesday", LanguageDay = "en", OrderNumber = 2 },
                    new DaysOfWeek { Id = 4, Day = "Вторник", LanguageDay = "mk", OrderNumber = 2 },
                    new DaysOfWeek { Id = 5, Day = "Wednesday", LanguageDay = "en", OrderNumber = 3 },
                    new DaysOfWeek { Id = 6, Day = "Среда", LanguageDay = "mk", OrderNumber = 3 },
                    new DaysOfWeek { Id = 7, Day = "Thurstdau", LanguageDay = "en", OrderNumber = 4 },
                    new DaysOfWeek { Id = 8, Day = "Четврток", LanguageDay = "mk", OrderNumber = 4 },
                    new DaysOfWeek { Id = 9, Day = "Friday", LanguageDay = "en", OrderNumber = 5 },
                    new DaysOfWeek { Id = 10, Day = "Петок", LanguageDay = "mk", OrderNumber = 5 },
                    new DaysOfWeek { Id = 11, Day = "Saturday", LanguageDay = "en", OrderNumber = 6 },
                    new DaysOfWeek { Id = 12, Day = "Сабота", LanguageDay = "mk", OrderNumber = 6 },
                    new DaysOfWeek { Id = 13, Day = "Sunday", LanguageDay = "en", OrderNumber = 7 },
                    new DaysOfWeek { Id = 14, Day = "Недела", LanguageDay = "mk", OrderNumber = 7 }
                    );
            });

            modelBuilder.Entity<WeatherInfo>(entity =>
            {
                entity.ToTable("WeatherInfo");

                entity.HasKey(e => e.Id);

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
