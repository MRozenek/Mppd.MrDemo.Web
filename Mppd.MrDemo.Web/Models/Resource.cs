namespace Mppd.MrDemo.Web.Models;

public partial class Resource
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public short ResourceTypeId { get; set; }

    public virtual ICollection<HierarchyTree> HierarchyTreeResourceManagers { get; set; } = new List<HierarchyTree>();

    public virtual ICollection<HierarchyTree> HierarchyTreeResourceParents { get; set; } = new List<HierarchyTree>();

    public virtual ICollection<HierarchyTree> HierarchyTreeResources { get; set; } = new List<HierarchyTree>();

    public virtual ResourceType ResourceType { get; set; } = null!;
}
