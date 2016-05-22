using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MovieSearch.Web.Models;

namespace MovieSearch.Web
{
    public partial class TitlesContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(local);Database=Titles;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>(entity =>
            {
                entity.Property(e => e.Award1)
                    .HasColumnName("Award")
                    .HasMaxLength(100);

                entity.Property(e => e.AwardCompany).HasMaxLength(100);

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Award)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Award_FK_Award_Title");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<OtherName>(entity =>
            {
                entity.Property(e => e.TitleName).HasMaxLength(100);

                entity.Property(e => e.TitleNameLanguage).HasMaxLength(100);

                entity.Property(e => e.TitleNameSortable).HasMaxLength(100);

                entity.Property(e => e.TitleNameType).HasMaxLength(100);

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.OtherName)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("OtherName_FK_OtherName_Title");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ParticipantType).HasMaxLength(100);
            });

            modelBuilder.Entity<StoryLine>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Language).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.StoryLine)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("StoryLine_FK_StoryLine_Title");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.TitleId).ValueGeneratedNever();

                entity.Property(e => e.ProcessedDateTimeUTC).HasColumnType("datetime");

                entity.Property(e => e.TitleName).HasMaxLength(100);

                entity.Property(e => e.TitleNameSortable).HasMaxLength(100);
            });

            modelBuilder.Entity<TitleGenre>(entity =>
            {
                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.TitleGenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("TitleGenre_FK_TitleGenre_Genre");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TitleGenre)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("TitleGenre_FK_TitleGenre_Title");
            });

            modelBuilder.Entity<TitleParticipant>(entity =>
            {
                entity.Property(e => e.RoleType).HasMaxLength(100);

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.TitleParticipant)
                    .HasForeignKey(d => d.ParticipantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("TitleParticipant_FK_TitleParticipant_Participant");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TitleParticipant)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("TitleParticipant_FK_TitleParticipant_Title");
            });
        }

        public virtual DbSet<Award> Award { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<OtherName> OtherName { get; set; }
        public virtual DbSet<Participant> Participant { get; set; }
        public virtual DbSet<StoryLine> StoryLine { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<TitleGenre> TitleGenre { get; set; }
        public virtual DbSet<TitleParticipant> TitleParticipant { get; set; }
    }
}