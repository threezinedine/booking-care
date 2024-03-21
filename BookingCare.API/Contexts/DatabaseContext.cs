using BookingCare.API.Models;
using BookingCare.API.Seeders;
using BookingCare.API.Services.PasswordHashingService;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace BookingCare.API.Contexts
{

    public class DatabaseContext : DbContext
	{
        public DbSet<Role> Roles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<ScheduleTime> ScheduleTimes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DatabaseContext(DbContextOptions options) 
            : base(options)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Role>().HasData(
				RoleSeeder.Patient,
                RoleSeeder.Doctor,
                RoleSeeder.Admin
            );

            modelBuilder.Entity<Position>().HasData(
                PositionSeeder.NonPosition,
                PositionSeeder.DoctorMD,
                PositionSeeder.DoctorDO,
                PositionSeeder.Professor,
                PositionSeeder.Fellow
            );

            modelBuilder.Entity<Specialty>().HasData(
                SpecialtySeeder.NonSpecialty,
                SpecialtySeeder.Cardiology,
                SpecialtySeeder.Dermatology,
                SpecialtySeeder.Endocrinology,
                SpecialtySeeder.Gastroenterology,
                SpecialtySeeder.Hematology,
                SpecialtySeeder.GeneralPractice,
                SpecialtySeeder.Neurology,
                SpecialtySeeder.Oncology,
                SpecialtySeeder.Ophthalmology,
                SpecialtySeeder.Otolaryngology,
                SpecialtySeeder.Pediatrics,
                SpecialtySeeder.Psychiatry,
                SpecialtySeeder.Radiology,
                SpecialtySeeder.Surgery,
                SpecialtySeeder.Urology,
                SpecialtySeeder.VascularSurgery,
                SpecialtySeeder.Nephrology,
                SpecialtySeeder.Pulmonology,
                SpecialtySeeder.InfectiousDisease
			);

            modelBuilder.Entity<ScheduleTime>().HasData(
                ScheduleTimeSeeder.EightToNine,
                ScheduleTimeSeeder.NineToTen,
                ScheduleTimeSeeder.TenToEleven,
                ScheduleTimeSeeder.ElevenToTwelve,
                ScheduleTimeSeeder.ThirteenToFourteen,
                ScheduleTimeSeeder.FourteenToFifteen,
                ScheduleTimeSeeder.FifteenToSixteen,
                ScheduleTimeSeeder.SixteenToSeventeen,
                ScheduleTimeSeeder.SeventeenToEighteen
			);
        }
	}
}
