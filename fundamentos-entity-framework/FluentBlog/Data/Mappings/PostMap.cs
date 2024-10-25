using FluentBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentBlog.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.CategoryId).IsRequired().HasColumnName("CategoryId").HasColumnType("INT");
            builder.Property(x => x.AuthorId).IsRequired().HasColumnName("AuthorId").HasColumnType("INT");
            builder.Property(x => x.Title).IsRequired().HasColumnName("Title").HasColumnType("VARCHAR").HasMaxLength(160);
            builder.Property(x => x.Summary).IsRequired().HasColumnName("Summary").HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.Body).IsRequired().HasColumnName("Body").HasColumnType("TEXT");
            builder.Property(x => x.Slug).IsRequired().HasColumnName("Slug").HasColumnType("VARCHAR").HasMaxLength(80);
            builder.Property(x => x.CreateDate).IsRequired().HasColumnName("CreateDate").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
            builder.Property(x => x.LastUpdateDate).IsRequired().HasColumnName("LastUpdateDate").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.HasIndex(x => x.Slug, "IX_Post_Slug").IsUnique();
        }
    }
}