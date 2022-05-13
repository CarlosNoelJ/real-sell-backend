using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WSVenta.Models.CustomeDataNotations;

namespace WSVenta.Models.Request
{
    public class VentaRequest
    {
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "El valor del idCliente debe ser mayor a 0")]
        [ExisteCliente(ErrorMessage = "El cliente no existe")]
        public int IdCliente { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Deben existir conceptos")]
        public List<ConceptoRequest> Conceptos { get; set; }


        public VentaRequest()
        {
            this.Conceptos = new List<ConceptoRequest>();
        }
    }
}
