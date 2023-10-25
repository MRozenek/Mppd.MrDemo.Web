using Microsoft.EntityFrameworkCore;

namespace Mppd.MrDemo.Web.Models;

public partial class MddpMrDemoContext : DbContext
{
    public MddpMrDemoContext()
    {
    }

    public MddpMrDemoContext(DbContextOptions<MddpMrDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HierarchyTree> HierarchyTrees { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<ResourceType> ResourceTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MddpMrDemo;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HierarchyTree>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HierarchyTreeId");

            entity.ToTable("HierarchyTree");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Resource).WithMany(p => p.HierarchyTreeResources)
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HierarchyTreeResourceId_ResourceId");

            entity.HasOne(d => d.ResourceManager).WithMany(p => p.HierarchyTreeResourceManagers)
                .HasForeignKey(d => d.ResourceManagerId)
                .HasConstraintName("FK_HierarchyTreeResourceManagerId_ResourceId");

            entity.HasOne(d => d.ResourceParent).WithMany(p => p.HierarchyTreeResourceParents)
                .HasForeignKey(d => d.ResourceParentId)
                .HasConstraintName("FK_HierarchyTreeResourceParentId_ResourceId");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ResourceId");

            entity.ToTable("Resource");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.ResourceType).WithMany(p => p.Resources)
                .HasForeignKey(d => d.ResourceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResourceTypeId_ResourceTypeId");
        });

        modelBuilder.Entity<ResourceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resource__3214EC07429671BC");

            entity.ToTable("ResourceType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
