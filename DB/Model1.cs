using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DB
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Compte> Compte { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Compte)
                .WithMany(e => e.Client)
                .Map(m => m.ToTable("Client_Compte").MapLeftKey("IdClient").MapRightKey("IdCompte"));

            modelBuilder.Entity<Compte>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Compte>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.Compte)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transactions>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
