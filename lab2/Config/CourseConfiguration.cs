using lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo3.Config
{
    public class CourseConfiguration :IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(s => s.CourseId);
            builder.Property(s => s.CourseId).ValueGeneratedNever();

            builder.Property(s => s.Crs_Name)
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnType("varchar");
            


        }
    }
}
