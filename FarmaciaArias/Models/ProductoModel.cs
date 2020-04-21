using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaArias.Models
{
    public class ProductoInputModel
    {
        public string CodigoP { get; set; }
        public string NombreP { get; set; }
        public string LaboratorioP { get; set; }
        public string Fechadevencimiento { get; set; }
        public int CantidadP { get; set; }      
    }

    public class ProductoViewModel : ProductoInputModel
    {
        public ProductoViewModel()
        {

        }
        public ProductoViewModel(Producto producto)
        {
            CodigoP = producto.CodigoP;
            NombreP = producto.NombreP;
            LaboratorioP = producto.LaboratorioP;
            Fechadevencimiento = producto.Fechadevencimiento;
            CantidadP = producto.CantidadP;
        }
    }
}