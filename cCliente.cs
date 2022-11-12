using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

using System.IO;

namespace tp_final
{
    public class cCliente
    {

        private int CodigoDeOperacion;
        private int Cant_productos;
        private cProducto.cListaProducto ProductosComprados; //TODO verificar si funciona el llamado a los elementos así

        #region Constructores y Destructores

        /// <summary>
        /// Constructor de cCliente
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Cant_productos_"></param>
        public cCliente(int Codigo, int Cant_productos_)
        {
            this.CodigoDeOperacion = Codigo;
            this.Cant_productos = Cant_productos_;
            this.ProductosComprados = new cProducto.cListaProducto();
        }


        /// <summary>
        /// Destructor de cCliente
        /// </summary>
        ~cCliente() { }

        #endregion Constructores y Destructores

        #region Funciones para imprimir
        override public string ToString() // TODO: Agregar al tostring los productos comprados  ??? que?
        {
            string aux = "";
            return aux += base.ToString() + ":\n" + CodigoDeOperacion.ToString() + "\n" + Cant_productos.ToString() + "\n";
        }

        #endregion Funciones para imprimir

        public int codigodeoperacion
        {
            get { return CodigoDeOperacion; }
            set { CodigoDeOperacion = value; }
        }

        public void Recibir(cProducto entrega)
        {
            ProductosComprados.Agregar(entrega);
        }

    }//end cCliente
}