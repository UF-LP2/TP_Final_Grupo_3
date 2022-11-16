using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


public class cCliente {

    private string Nombre;
	private int CodigoDeOperacion;
    private eZona Zona;
	private int Cant_productos;
	private cProducto.cListaProducto ProductosComprados; //TODO verificar si funciona el llamado a los elementos as�

    #region Constructores y Destructores

    /// <summary>
    /// Constructor de cCliente
    /// </summary>
    /// <param name="Codigo"></param>
    /// <param name="Cant_productos_"></param>
    public cCliente(string nombre_, int Codigo, int Cant_productos_, eZona Zona_){
		this.CodigoDeOperacion=Codigo;
        this.Zona = Zona_;
		this.Cant_productos=Cant_productos_;
		this.ProductosComprados = new cProducto.cListaProducto();
        this.Nombre = nombre_;
	}


	/// <summary>
	/// Destructor de cCliente
	/// </summary>
	~cCliente(){ }

    #endregion Constructores y Destructores

    #region Funciones para imprimir
    override public string ToString() 
	{
        string o = "------ CLIENTE CODIGO " + codigodeoperacion.ToString() +" ------";
        o+= "\nNombre: " + Nombre;
        o+= "\nZona de entrega: " + Zona.ToString();
        o+= "\nCantidad de productos comprados: " + Cant_productos.ToString();
        
        o+="\n\n--- PRODUCTOS RECIBIDOS";

        int i = 0;
        if(ProductosComprados.GetCount() > 0)
        {
            while(i<ProductosComprados.GetCount()){
                o+="\n" + ProductosComprados[i].ToString();
                i++;
            }
        }
        else{o+="\nNo recibio ningun producto hasta el momento";}

		return o;
    }

    #endregion Funciones para imprimir

    public int codigodeoperacion
    {
        get { return CodigoDeOperacion; }
        set { CodigoDeOperacion = value; }
    }

    public eZona zona{get{return Zona;}}
    public int CantidadProductos { get { return Cant_productos; } }

    public int CantidadRecibidos { get { return ProductosComprados.GetCount(); } }

    public void Recibir(cProducto entrega)
    {
        ProductosComprados.Agregar(entrega);
    }

}//end cCliente