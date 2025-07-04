﻿using Islamic_Face_Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Islamic_Face_Data_Access.context.Config
{
    public class PostMediaConfig : IEntityTypeConfiguration<PostMedia>
    {
        public void Configure(EntityTypeBuilder<PostMedia> builder)
        {
            builder.ToTable("PostMedias");
            builder.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1, 1");

            builder.Property(x => x.Id)
              .HasColumnType("BigInt")
              .IsRequired();

            builder.Property(x => x.postId)
               .HasColumnType("BigInt")
               .IsRequired();
            
            builder.Property(x => x.mediaType)
               .HasColumnType("tinyInt")
               .IsRequired();
           
            builder.Property(x => x.mediaURL)
               .HasColumnType("VARCHAR")
               .HasMaxLength(2083)
               .IsRequired();

           

           
        }
    }
}
