using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Producto : BusinessEntities
    {
        private string _Descripcion;
        public string Descripcion
        {
            set { _Descripcion = value; }
            get { return _Descripcion; }
        }

        private float _Precio;
        public float Precio
        {
            set { _Precio = value; }
            get { return _Precio; }
        }
    }
}
