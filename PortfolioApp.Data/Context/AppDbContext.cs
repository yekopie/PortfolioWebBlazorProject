using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data.Entities;
using PortfolioApp.MinimalCore.Security;

namespace PortfolioApp.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Images
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, Path = "/images/projects/project-11.jpg", Name = "Project-1" },
                new Image { Id = 2, Path = "/images/projects/project-2.jpg", Name = "Project-2" },
                new Image { Id = 3, Path = "/images/projects/project-3.jpg", Name = "Project-3" },
                new Image { Id = 4, Path = "/images/projects/project-4.jpg", Name = "Project-4" },
                new Image { Id = 5, Path = "/images/testimonials/testimonial-1.jpg", Name = "User-1" },
                new Image { Id = 6, Path = "/images/testimonials/testimonial-2.jpg", Name = "User-2" },
                new Image { Id = 7, Path = "/images/testimonials/testimonial-3.jpg", Name = "User-3" },
                new Image { Id = 8, Path = "/images/testimonials/testimonial-4.jpg", Name = "User-4" }
            );

            // Education
            modelBuilder.Entity<Education>().HasData(
                new Education { Id = 1, Degree = "Bachelor of Science", Field = "Computer Science", School = "MIT", StartDate = new DateOnly(2015, 9, 1), EndDate = new DateOnly(2019, 6, 30), Description = "Focused on software development, algorithms, and AI.", ProfileId = 1},
                new Education { Id = 2, Degree = "Master of Science", Field = "Data Science", School = "Stanford University", StartDate = new DateOnly(2020, 9, 1), EndDate = new DateOnly(2022, 6, 30), Description = "Specialized in machine learning and big data analytics.", ProfileId = 1 },
                new Education { Id = 3, Degree = "High School Diploma", Field = "Science", School = "Springfield High School", StartDate = new DateOnly(2010, 9, 1), EndDate = new DateOnly(2014, 6, 30), Description = null, ProfileId = 1 }
            );

            // Experience
            modelBuilder.Entity<Experience>().HasData(
                new Experience { Id = 1, JobTitle = "Junior Backend Developer", Company = "TechSoft Inc.", CompanyAdress = "Istanbul, Turkiye", StartDate = new DateOnly(2019, 7, 1), EndDate = new DateOnly(2021, 12, 31), Description = "Developed APIs, maintained database systems, and optimized backend performance.", ProfileId = 1 },
                new Experience { Id = 2, JobTitle = "Backend Developer", CompanyAdress = "Istanbul, Turkiye", Company = "DataSolutions", StartDate = new DateOnly(2022, 1, 1), EndDate = null, Description = "Building microservices, integrating third-party services, and improving system scalability.", ProfileId = 1 },
                new Experience { Id = 3, JobTitle = "Intern", Company = "InnovateLabs", CompanyAdress = "Istanbul, Turkiye", StartDate = new DateOnly(2018, 6, 1), EndDate = new DateOnly(2018, 8, 31), Description = "Assisted in developing internal tools and learned industry best practices.", ProfileId = 1 },
                new Experience { Id = 4, JobTitle = "Freelance Developer", CompanyAdress = "Istanbul, Turkiye", Company = "Self-employed", StartDate = new DateOnly(2017, 3, 1), EndDate = new DateOnly(2019, 6, 30), Description = "Worked on various small projects including web apps, automation scripts, and APIs.", ProfileId = 1 }
            );

            // Projects
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Portfolio Website", ProjectLink = "https://github.com/user/portfolio", Description = "Personal portfolio site to showcase projects and skills.", PublishDate = new DateOnly(2023, 2, 15), ImageId = 1, ProfileId = 1 },
                new Project { Id = 2, Name = "E-Commerce App", ProjectLink = "https://github.com/user/ecommerce", Description = "A full-stack e-commerce application with shopping cart and payment integration.", PublishDate = new DateOnly(2022, 11, 10), ImageId = 2, ProfileId = 1 },
                new Project { Id = 3, Name = "Blog Platform", ProjectLink = "https://github.com/user/blog", Description = "A blogging platform with user authentication and rich text editor.", PublishDate = new DateOnly(2021, 8, 5), ImageId = 3, ProfileId = 1 },
                new Project { Id = 4, Name = "Task Manager", ProjectLink = "https://github.com/user/taskmanager", Description = "A task management app with categories, priorities, and deadlines.", PublishDate = null, ImageId = 4, ProfileId = 1 }
            );

            // Skills
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#", Percentage = 90, ProfileId = 1 },
                new Skill { Id = 2, Name = "ASP.NET Core", Percentage = 85, ProfileId = 1 },
                new Skill { Id = 3, Name = "Blazor", Percentage = 80, ProfileId = 1 },
                new Skill { Id = 4, Name = "Entity Framework", Percentage = 85, ProfileId = 1 },
                new Skill { Id = 5, Name = "SQL", Percentage = 80, ProfileId = 1 },
                new Skill { Id = 6, Name = "REST API", Percentage = 75, ProfileId = 1 },
                new Skill { Id = 7, Name = "JavaScript", Percentage = 70, ProfileId = 1 },
                new Skill { Id = 8, Name = "HTML & CSS", Percentage = 85, ProfileId = 1 },
                new Skill { Id = 9, Name = "Git", Percentage = 80, ProfileId = 1 },
                new Skill { Id = 10, Name = "Docker", Percentage = 65, ProfileId = 1 }
            );

            // Testimonials
            modelBuilder.Entity<Testimonial>().HasData(
                new Testimonial { Id = 1, FullName = "Alice Johnson", Stars = 5, Review = "Excellent developer, delivered all tasks on time and with great quality.", ImageId = 5, ProfileId = 1 },
                new Testimonial { Id = 2, FullName = "Bob Smith", Stars = 4, Review = "Very professional and responsive. Highly recommend!", ImageId = 6, ProfileId = 1 },
                new Testimonial { Id = 3, FullName = "Clara Lee", Stars = 5, Review = "Great collaboration experience, very knowledgeable.", ImageId = 7, ProfileId = 1 },
                new Testimonial { Id = 4, FullName = "David Kim", Stars = 4, Review = "Delivered quality code and met deadlines.", ImageId = 8, ProfileId = 1 }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "yekopie",
                    PasswordHash = HashingHelper.HashPassword("admin123"), // Örnek hash, gerçek projede Identity kullan
                    ProfileId = 1
                }
            );

            modelBuilder.Entity<Profile>().HasData(
                            new Profile
                            {
                                Id = 1,
                                Name = "Yekopie Portfolio",
                                Title = "Junior Backend Developer",
                                About = "Passionate backend developer with experience in C# and modern web technologies.",
                                Summary = "I specialize in building clean, maintainable, and scalable backend architectures.",
                                Email = "yekopie@example.com",
                                Phone = "+90 555 555 5555",
                                Address = "Istanbul, Turkey",
                                Profession = "Software Developer",
                                FreelanceStatus = "Available",
                                ImageUrl = "/images/profile-img.jpg",
                                Birthday = new DateOnly(1999, 5, 11),
                                UserId = 1
                            }
                        );
            modelBuilder.Entity<SocialMedia>().HasData(
                new SocialMedia { Id = 1, Icon = "bi bi-twitter-x", Link = "https://twitter.com/yekopie", ProfileId = 1 },
                new SocialMedia { Id = 2, Icon = "bi bi-facebook", Link = "https://facebook.com/yekopie", ProfileId = 1 },
                new SocialMedia { Id = 3, Icon = "bi bi-instagram", Link = "https://instagram.com/yekopie", ProfileId = 1 },
                new SocialMedia { Id = 4, Icon = "bi bi-linkedin", Link = "https://www.linkedin.com/in/yekopie", ProfileId = 1 }
            );

        }
    }
}