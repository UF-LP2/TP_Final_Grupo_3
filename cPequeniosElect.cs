using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

using System.IO;
using tp_final;

namespace tp_final
{
    /*   internal class cPequeniosElect
       {
       }*/
    public class cPequeniosElect : cProducto
    {

        /// 
        /// <param name="Tipo"></param>
        /// <param name="ZonaEntrega"></param>
        /// <param name="Entrega"></param>
        /// <param name="Dimensiones_"></param>
        /// <param name="Codigo_"></param>
        /// <param name="ascensor_"></param>
        public cPequeniosElect(eProducto Tipo_, cZona ZonaEntrega, eTipoEntrega Entrega, dimensiones Dimensiones_, int Codigo_, bool ascensor_) : base(Tipo_, ZonaEntrega, Entrega, Dimensiones_, Codigo_, ascensor_)
        {


        }

        ~cPequeniosElect()
        {

        }

    }//end cPequeniosElect
}



