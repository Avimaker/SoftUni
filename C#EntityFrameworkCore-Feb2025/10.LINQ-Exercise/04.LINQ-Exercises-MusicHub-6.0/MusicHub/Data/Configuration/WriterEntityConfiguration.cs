﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configuration
{
    using static EntityValidationConstants.Writer;


    public class WriterEntityConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> entity)
        {
            entity.HasKey(w => w.Id);

            entity
                .Property(w => w.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(WriterNameMaxLength);

            entity
                .Property(w => w.Pseudonym)
                .IsRequired(false)
                .IsUnicode();
        }
    }
}

