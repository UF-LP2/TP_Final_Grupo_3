using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using tp_final;

// TODO: Chequear si es necesario poner el eProducto o se puede hacer el chequeo con dynamic cast? igual el enum lo facilita 
// Pero capaz creen que es repetitivo no se
namespace tp_final
{
    public class cElectronicos : cProducto
    {

        /// 
        /// <param name="Tipo_"></param>
        /// <param name="ZonaEntrega"></param>
        /// <param name="Entrega"></param>
        /// <param name="Dimensiones_"></param>
        /// <param name="Codigo_"></param>
        /// <param name="ascensor_"></param>
        public cElectronicos(eProducto Tipo_, cZona ZonaEntrega, eTipoEntrega Entrega, dimensiones Dimensiones_, int Codigo_, bool ascensor_) : base(Tipo_, ZonaEntrega, Entrega, Dimensiones_, Codigo_, ascensor_)
        {

        }

        ~cElectronicos()
        {

        }

    }//end cElectronicos
}