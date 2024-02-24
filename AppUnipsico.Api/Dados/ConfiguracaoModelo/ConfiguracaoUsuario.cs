﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Data.ConfigurationModel
{
    public class ConfiguracaoUsuario : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder
                .HasKey(u => u.UsuarioId);

            builder
                .HasIndex(u => u.UsuarioCpf)
                .IsUnique();

            builder
                .HasIndex(u => u.UsuarioEmail)
                .IsUnique();
        }
    }
}