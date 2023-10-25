namespace Mppd.MrDemo.Web.Models;

public partial class HierarchyTree
{
    public int Id { get; set; }

    public int ResourceId { get; set; }

    public int? ResourceParentId { get; set; }

    public int? ResourceManagerId { get; set; }

    public virtual Resource Resource { get; set; } = null!;

    public virtual Resource? ResourceManager { get; set; }

    public virtual Resource? ResourceParent { get; set; }
}
