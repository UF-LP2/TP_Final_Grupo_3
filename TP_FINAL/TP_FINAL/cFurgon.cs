using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


public class cFurgon : cVehiculo {

	/// 
	/// <param name="VolumenMAX"></param>
	/// <param name="PesoMAX"></param>
	/// <param name="repartos_max"></param>
	/// <param name="consumo"></param>
	/// <param name="ascensor_"></param>
	public cFurgon(int VolumenMAX, float PesoMAX, int repartos_max, float consumo, bool ascensor_, float alto_) : base(VolumenMAX, PesoMAX, repartos_max, consumo, ascensor_, alto_)
    {

	}

	~cFurgon(){

	}

}//end cFurgon