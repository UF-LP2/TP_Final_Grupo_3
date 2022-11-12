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
    public class cFurgon : cVehiculo
    {

        /// 
        /// <param name="VolumenMAX"></param>
        /// <param name="PesoMAX"></param>
        /// <param name="repartos_max"></param>
        /// <param name="consumo"></param>
        /// <param name="ascensor_"></param>
        public cFurgon(int VolumenMAX, float PesoMAX, int repartos_max, float consumo, bool ascensor_, float alto_) : base(VolumenMAX, PesoMAX, repartos_max, consumo, ascensor_, alto_)
        {

        }

        ~cFurgon()
        {

        }

    }//end cFurgon
}