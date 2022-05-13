using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WSVenta.Models;
using WSVenta.Models.Request;
using WSVenta.Models.Response;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(VentaRequest model)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    var venta = new Venta();
                    venta.Total = model.Total;
                    venta.Fecha = DateTime.Now;
                    venta.IdCliente = model.IdCliente;
                    db.Venta.Add(venta);
                    db.SaveChanges();

                    foreach (var modelConcepto in model.Conceptos){
                        Concepto concepto = new Models.Concepto();
                        concepto.Cantidad = modelConcepto.Cantidad;
                        concepto.IdProducto = modelConcepto.IdProducto;
                        concepto.PrecioUnitario = modelConcepto.PrecioUnitario;
                        concepto.Importe = modelConcepto.Importe;
                        concepto.IdVenta = venta.Id;
                        db.Concepto.Add(concepto);
                        db.SaveChanges();
                    }

                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }
    }
}
