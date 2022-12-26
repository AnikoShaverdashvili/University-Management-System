using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem_Final.Configurations;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final
{
    public class UniversityManagementSystemDbContext : DbContext
    {
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Balance>? Balances { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Schedule>? Schedules { get; set; }
        public DbSet<Semester>? Semesters { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<StudentSubject>? StudentSubjects { get; set; }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
        public UniversityManagementSystemDbContext(DbContextOptions<UniversityManagementSystemDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AddressConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BalanceConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoomConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduleConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SemesterConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentSubjectConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubjectConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeacherConfiguration).Assembly);

        }
    }
}
