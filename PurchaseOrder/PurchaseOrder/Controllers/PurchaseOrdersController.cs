using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrder.Data;
using PurchaseOrder.DTOs;
using PurchaseOrder.Models;

namespace PurchaseOrder.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOrdersController : ControllerBase
{
    private readonly AppDbContext _db;

    public PurchaseOrdersController(AppDbContext db)
    {
        _db = db;
    }

    // GET: api/PurchaseOrders
    // Filtering, Sorting, Pagination
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PoQueryParameters query)
    {
        var data = _db.PurchaseOrders.AsQueryable();

        // Filtering
        if (!string.IsNullOrWhiteSpace(query.Supplier))
            data = data.Where(p => p.SupplierName.Contains(query.Supplier));

        if (!string.IsNullOrWhiteSpace(query.Status))
            data = data.Where(p => p.Status.ToString() == query.Status);

        if (query.FromDate.HasValue)
            data = data.Where(p => p.OrderDate >= query.FromDate.Value);

        if (query.ToDate.HasValue)
            data = data.Where(p => p.OrderDate <= query.ToDate.Value);

        // Sorting
        data = query.SortBy switch
        {
            "PoNumber" => query.Desc
                ? data.OrderByDescending(p => p.PoNumber)
                : data.OrderBy(p => p.PoNumber),

            "TotalAmount" => query.Desc
                ? data.OrderByDescending(p => p.TotalAmount)
                : data.OrderBy(p => p.TotalAmount),

            _ => query.Desc
                ? data.OrderByDescending(p => p.OrderDate)
                : data.OrderBy(p => p.OrderDate)
        };

        // Pagination
        var totalCount = await data.CountAsync();

        var items = await data
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

        return Ok(new { totalCount, items });
    }

    // GET: api/PurchaseOrders/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var po = await _db.PurchaseOrders.FindAsync(id);
        if (po == null) return NotFound();

        return Ok(po);
    }

    // POST: api/PurchaseOrders
    [HttpPost]
    public async Task<IActionResult> Create(PurchaseOrderEntity po)
    {
        _db.PurchaseOrders.Add(po);
        await _db.SaveChangesAsync();

        return Ok(po);
    }

    // PUT: api/PurchaseOrders/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PurchaseOrderEntity po)
    {
        if (id != po.Id) return BadRequest();

        _db.Entry(po).State = EntityState.Modified;
        await _db.SaveChangesAsync();

        return Ok(po);
    }

    // DELETE: api/PurchaseOrders/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var po = await _db.PurchaseOrders.FindAsync(id);
        if (po == null) return NotFound();

        _db.PurchaseOrders.Remove(po);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
