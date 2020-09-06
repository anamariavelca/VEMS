using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.API.Models.Entities;
using VEMS.API.Models.Identity;

namespace VEMS.API.Data.Extensions
{
    public static class DbTableConfiguration
    {
        public static void ApplyDbTableConfiguration(this ModelBuilder builder)
        {
            /**
             * Exams table configuration
             */
            builder.Entity<Exam>().ToTable("Exam");

            builder.Entity<Exam>()
                .Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<Exam>()
                .Property(e => e.Description)
                .HasMaxLength(200);

            builder.Entity<Exam>()
                .Property(e => e.Duration)
                .IsRequired();

            builder.Entity<Exam>()
                .Property(e => e.Status)
                .IsRequired();

            //Relationships
            builder.Entity<Exam>()
                .HasMany<ExamQuestion>(e => e.ExamQuestions)
                .WithOne(eq => eq.Exam)
                .HasForeignKey(eq => eq.ExamId);

            builder.Entity<Exam>()
                .HasMany<UserExam>(e => e.UserExams)
                .WithOne(ue => ue.Exam)
                .HasForeignKey(ue => ue.ExamId);

            /**
             * ExamQuestion table configuration
             */
            builder.Entity<ExamQuestion>().ToTable("ExamQuestion")
                .HasKey(eq => new
                {
                    eq.ExamId,
                    eq.QuestionId
                });

            /**
             * Question table configuration
             */
            builder.Entity<Question>().ToTable("Question");

            builder.Entity<Question>()
                .Property(q => q.Title)
                .HasMaxLength(300)
                .IsRequired();

            builder.Entity<Question>()
                .Property(q => q.Type)
                .IsRequired();

            builder.Entity<Question>()
                .Property(q => q.RatePolicyType)
                .IsRequired();

            //Relationships
            builder.Entity<Question>()
                .HasMany<ExamQuestion>(q => q.ExamQuestions)
                .WithOne(eq => eq.Question)
                .HasForeignKey(eq => eq.QuestionId);

            builder.Entity<Question>()
                .HasMany<Option>(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId);

            /**
             * Option table configuration
             */
            builder.Entity<Option>().ToTable("Option");

            builder.Entity<Option>()
               .Property(o => o.Title)
               .HasMaxLength(300)
               .IsRequired();

            builder.Entity<Option>()
               .Property(o => o.ImageUrl)
               .HasMaxLength(200);

            builder.Entity<Option>()
               .Property(o => o.Score)
               .IsRequired();

            //Relationships
            builder.Entity<Option>()
                .HasMany<UserAnswer>(o => o.UserAnswers)
                .WithOne(ua => ua.Option)
                .HasForeignKey(ua => ua.OptionId);

            /**
             * UserAnswer table configuration
             */
            builder.Entity<UserAnswer>().ToTable("UserAnswer");

            /**
             * UserExam table configuration
             */
            builder.Entity<UserExam>().ToTable("UserExam");

            builder.Entity<UserExam>()
               .Property(ue => ue.Status)
               .IsRequired();

            /*builder.Entity<UserExam>()
                .HasCheckConstraint("CK_UserExams_Score", "[Score] <= (5)");*/

            //Relationships
            builder.Entity<UserExam>()
                .HasMany<UserAnswer>(ue => ue.UserAnswers)
                .WithOne(ua => ua.UserExam)
                .HasForeignKey(ua => ua.UserExamId);
        }

        public static void SeedDB(this ModelBuilder modelBuilder)
        {
            //Default Roles
            var roles = new[]
            {
                new ApplicationRole
                {
                    Id = Guid.NewGuid(),
                    Name = "Teacher",
                    NormalizedName = "TEACHER"
                },
                new ApplicationRole
                {
                    Id = Guid.NewGuid(),
                    Name = "Student",
                    NormalizedName = "STUDENT"
                }
            };
            modelBuilder.Entity<ApplicationRole>().HasData(roles);
        }
    }
}
