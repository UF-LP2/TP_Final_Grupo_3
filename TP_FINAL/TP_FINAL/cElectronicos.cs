using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

// TODO: Chequear si es necesario poner el eProducto o se puede hacer el chequeo con dynamic cast? igual el enum lo facilita 
// Pero capaz creen que es repetitivo no se

public class cElectronicos : cProducto {

	/// 
	/// <param name="Tipo_"></param>
	/// <param name="ZonaEntrega"></param>
	/// <param name="Entrega"></param>
	/// <param name="Peso"></param>
	/// <param name="Alto_"></param>
	/// <param name="Ancho_"></param>
	/// <param name="Largo_"></param>
	/// <param name="Codigo"></param>
	/// <param name="ascensor_"></param>
	public cElectronicos(eProducto Tipo_, eZona ZonaEntrega, eTipoEntrega Entrega, float Peso, sDimensiones Dimensiones_, int Codigo_, bool ascensor_) : base(Tipo_, ZonaEntrega, Entrega, Peso, Dimensiones_, Codigo_, ascensor_)
    {

	}

	~cElectronicos(){

	}

}//end cElectronicos