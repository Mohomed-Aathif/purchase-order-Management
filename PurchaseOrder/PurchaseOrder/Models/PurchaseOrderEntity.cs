using System.ComponentModel.DataAnnotations;

namespace PurchaseOrder.Models;

public enum PoStatus
{
    Draft,
    Approved,
    Shipped,
    Completed,
    Cancelled
}

public class PurchaseOrderEntity
{
    public int Id { get; set; }

    [Required]
    public string PoNumber { get; set; } = string.Empty;

    public string PoDescription { get; set; } = string.Empty;

    [Required]
    public string SupplierName { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Range(0, double.MaxValue)]
    public decimal TotalAmount { get; set; }

    public PoStatus Status { get; set; } = PoStatus.Draft;
}
