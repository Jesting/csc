public partial class Product
{
    public int Id { get; set; }
    
    public int? ProductGroupId { get; set; }

    public virtual ProcuctGroup? ProductGroup { get; set; }

    public string? Name { get; set; } = null;

    public string? Description { get; set; } = null;

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

}
