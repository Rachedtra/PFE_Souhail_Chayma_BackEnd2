using Microsoft.EntityFrameworkCore;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Data.Context
{
    public class GestionCommContext : DbContext
    {
        public GestionCommContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Commentaires> Commentaires { get; set; }
        public DbSet<DemandeInformation> DemandeInformation { get; set; }
        public DbSet<SousCategorie> SousCategories { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<CatDemandeInfo> CatDemandeInfos { get; set; }
        public DbSet<CommDemandeInfo> CommDemandeInfos { get; set; }
        public DbSet<CommVote> CommVotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>(entity => entity
               .HasKey(d => d.IdCat));
            modelBuilder.Entity<Commentaires>(entity => entity
             .HasKey(d => d.IdComm));
            modelBuilder.Entity<DemandeInformation>(entity => entity
             .HasKey(d => d.IdDemandeInfo));
            modelBuilder.Entity<SousCategorie>(entity => entity
             .HasKey(d => d.IdSousCate));
            modelBuilder.Entity<Vote>(entity => entity
             .HasKey(d => d.IdVote));
            modelBuilder.Entity<CatDemandeInfo>(entity => entity
              .HasKey(d => d.IdCatDemande));
            modelBuilder.Entity<CommDemandeInfo>(entity => entity
              .HasKey(d => d.IdCommInfo));
            modelBuilder.Entity<CommVote>(entity => entity
              .HasKey(d => d.IdCommVote));

            modelBuilder.Entity<CatDemandeInfo>()//many to many
              .HasOne(e => e.categories)
              .WithMany(s => s.catDemandeInfos)
               .HasForeignKey(p => p.IdCat);

            modelBuilder.Entity<CatDemandeInfo>()//many to many
               .HasOne(e => e.demandeInformations)
               .WithMany(s => s.catDemandeInfos)
                .HasForeignKey(p => p.IdDemandeInfo);

            modelBuilder.Entity<CommDemandeInfo>()//many to many
             .HasOne(e => e.commentaires)
             .WithMany(s => s.commDemandeInfos)
              .HasForeignKey(p => p.IdComm);

            modelBuilder.Entity<CommDemandeInfo>()//many to many
               .HasOne(e => e.demandeInformations)
               .WithMany(s => s.commDemandeInfos)
                .HasForeignKey(p => p.IdDemandeInfo);

            modelBuilder.Entity<CommVote>()//many to many
        .HasOne(e => e.votes)
        .WithMany(s => s.commVotes)
         .HasForeignKey(p => p.IdVote);

            modelBuilder.Entity<CommVote>()//many to many
               .HasOne(e => e.commentaires)
               .WithMany(s => s.commVotes)
                .HasForeignKey(p => p.IdVote);

            modelBuilder.Entity<SousCategorie>()
               .HasOne(e => e.Categories)
               .WithMany(s => s.sousCategories)
                .HasForeignKey(p => p.CatFK)
                .OnDelete(DeleteBehavior.ClientSetNull); //one to many

        }
    }
}
