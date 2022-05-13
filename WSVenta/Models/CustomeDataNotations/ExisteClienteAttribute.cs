using System.ComponentModel.DataAnnotations;

namespace WSVenta.Models.CustomeDataNotations
{
    public class ExisteClienteAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int idCliente = (int)value;
            using (var db = new VentaRealContext())
            {
                if (db.Cliente.Find(idCliente) == null)
                    return false;
            }

            return true;
        }
    }
}
