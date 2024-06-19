using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class HopitalContext:IdentityDbContext<AddOnApplicationUser>
    {
        public DbSet<Hosptial> Hosptial { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public  DbSet<WorkSchedule> WorkSchedules { get; set; }
        public  DbSet<Department> Department { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Doctor> doctors { get; set; }

        public HopitalContext(DbContextOptions options):base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });
            });



        modelBuilder.Entity<Hosptial>().HasData(
            new Hosptial { Id = 1, Address = "Alex", Name = "Alex"},
            new Hosptial { Id = 2, Address = "Cairo", Name = "Cairo" }
            );


            modelBuilder.Entity<Department>().HasData(
new Department { Id = 1, Name = "Cardiology", HosptialID = 1, Description = "The cardiology department specializes in the diagnosis and treatment of heart diseases and conditions.", deptImage = "https://www.centrecardiolaval.com/wp-content/uploads/2023/07/medical-concept-with-heart-and-electrocardiogram-r-2021-08-31-15-58-51-utc-1536x1024.jpg" },
new Department { Id = 2, Name = "Neurology", HosptialID = 1, Description = "The neurology department specializes in the diagnosis and treatment of diseases and conditions of the brain, spinal cord, and peripheral nerves.", deptImage = "https://muthumeenakshihospitals.com/img/Neurology-and-Neurosurgery.png" },
new Department { Id = 3, Name = "Orthopedics", HosptialID = 1, Description = "The orthopedics department specializes in the diagnosis and treatment of diseases and conditions of the musculoskeletal system, including bones, joints, muscles, and ligaments.", deptImage = "https://sayaamed.com/wp-content/uploads/2022/01/Orthopedics-in-sayaa-med-1.jpg" },
new Department { Id = 4, Name = "Pediatrics", HosptialID = 1, Description = "The pediatrics department specializes in the diagnosis and treatment of diseases and conditions of children from birth to adolescence.", deptImage = "https://wakeforestpediatrics.com/wp-content/uploads/2020/10/Choosing-a-Pediatrician.jpeg" },
new Department { Id = 5, Name = "Surgery", HosptialID = 1, Description = "The surgery department specializes in the diagnosis and treatment of diseases and conditions that require surgical intervention.", deptImage = "https://i0.wp.com/post.medicalnewstoday.com/wp-content/uploads/sites/3/2023/03/cosmetic_surgery_GettyImages1313477062_Header-1024x575.jpg?w=1155&h=1528" },
new Department { Id = 6, Name = "Cardiology", HosptialID = 2, Description = "The cardiology department specializes in the diagnosis and treatment of heart diseases and conditions.", deptImage = "https://www.centrecardiolaval.com/wp-content/uploads/2023/07/medical-concept-with-heart-and-electrocardiogram-r-2021-08-31-15-58-51-utc-1536x1024.jpg" },
new Department { Id = 7, Name = "Neurology", HosptialID = 2, Description = "The neurology department specializes in the diagnosis and treatment of diseases and conditions of the brain, spinal cord, and peripheral nerves.", deptImage = "https://muthumeenakshihospitals.com/img/Neurology-and-Neurosurgery.png" },
new Department { Id = 8, Name = "Orthopedics", HosptialID = 2, Description = "The orthopedics department specializes in the diagnosis and treatment of diseases and conditions of the musculoskeletal system, including bones, joints, muscles, and ligaments.", deptImage = "https://sayaamed.com/wp-content/uploads/2022/01/Orthopedics-in-sayaa-med-1.jpg" },
new Department { Id = 9, Name = "Pediatrics", HosptialID = 2, Description = "The pediatrics department specializes in the diagnosis and treatment of diseases and conditions of children from birth to adolescence.", deptImage = "https://wakeforestpediatrics.com/wp-content/uploads/2020/10/Choosing-a-Pediatrician.jpeg" },
new Department { Id = 10, Name = "Surgery", HosptialID = 2, Description = "The surgery department specializes in the diagnosis and treatment of diseases and conditions that require surgical intervention.", deptImage = "https://i0.wp.com/post.medicalnewstoday.com/wp-content/uploads/sites/3/2023/03/cosmetic_surgery_GettyImages1313477062_Header-1024x575.jpg?w=1155&h=1528" }

                );

           

        }

    }
}
