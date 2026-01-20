namespace PurchaseOrder.DTOs;

public class PoQueryParameters
{
    public string? Supplier { get; set; }
    public string? Status { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }

    public string SortBy { get; set; } = "OrderDate";
    public bool Desc { get; set; } = false;

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
