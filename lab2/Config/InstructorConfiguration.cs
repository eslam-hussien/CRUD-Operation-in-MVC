using lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo3.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(a=>a.Department)
                .WithMany(a=>a.Instructors)
                .HasForeignKey(a=>a.FK_DeptNo)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

           

        }
    }
}
