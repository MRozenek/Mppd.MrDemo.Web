namespace Mppd.MrDemo.Web.Models;

public partial class ResourceType
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
}
