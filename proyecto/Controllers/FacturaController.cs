using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Datos;
using FacturaModel;

[Route("api/[controller]")]
[ApiController]
public class FacturaController : ControllerBase
{
    private readonly FacturaService _facturaService;
    public IConfiguration Configuration { get; }
    public FacturaController(HotelContext context)
    {
        _facturaService = new FacturaService(context);
    }
    // GET: api/Persona​
    [HttpGet]
    public ActionResult<FacturaViewModel> Gets()
    {
        var response = _facturaService.ConsultarTodos();
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        else
        {
            return Ok(response.Facturas.Select(p => new FacturaViewModel(p)));
        }
    }
    // GET: api/Persona/5​
    [HttpGet("{numerofactura}")]
    public ActionResult<FacturaViewModel> Get(string numerofactura)
    {
        var factura = _facturaService.BuscarxIdentificacion(numerofactura);
        if (factura == null) return NotFound();
        var facturaViewModel = new FacturaViewModel(factura);
        return facturaViewModel;
    }

    // POST: api/Persona​

    [HttpPost]
    public ActionResult<FacturaViewModel> Post(FacturaInputModel facturaInput)
    {
        Factura factura = MapearFactura(facturaInput);
        var response = _facturaService.Guardar(factura);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Factura);
    }

    // DELETE: api/Persona/5​

    [HttpDelete("{numerofactura}")]
    public ActionResult<string> Delete(string numerofactura)
    {
        string mensaje = _facturaService.Eliminar(numerofactura);
        return Ok(mensaje);
    }

    private Factura MapearFactura(FacturaInputModel facturaInput)
    {
        var factura = new Factura
        {
            IdFactura = facturaInput.IdFactura,
            FechaFactura = facturaInput.FechaFactura,
            Iva = facturaInput.Iva,
            Subtotal = facturaInput.Subtotal,
            Total = facturaInput.Total,
            FechaEntrada = facturaInput.FechaEntrada,
            FechaSalida = facturaInput.FechaSalida,
        };
        return factura;
    }
}