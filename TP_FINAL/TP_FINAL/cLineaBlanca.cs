using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class cLineaBlanca : cProducto {


	/// 
	/// <param name="Tipo"></param>
	/// <param name="ZonaEntrega"></param>
	/// <param name="Entrega"></param>
	/// <param name="Peso"></param>
	/// <param name="Alto_"></param>
	/// <param name="Ancho_"></param>
	/// <param name="Largo_"></param>
	/// <param name="Codigo"></param>
	/// <param name="ascensor_"></param>
	public cLineaBlanca(eProducto Tipo_, eZona ZonaEntrega, eTipoEntrega Entrega, float Peso, sDimensiones Dimensiones_, int Codigo_, bool ascensor_) : base(Tipo_, ZonaEntrega, Entrega, Peso, Dimensiones_, Codigo_, ascensor_)
    {

	}

	~cLineaBlanca(){

	}

}//end cLineaBlanca