using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class cDeposito {

	private eZona Origen;
	private List<cCliente> ClientesAEntregar;
	private cProducto.cListaProducto ProductosADespachar;

    private cZona.cListaZonas Mapa;
    private List<cVehiculo> Camiones;


	#region Constructores y Destructores
	/// <param name="Origen"></param>
	public cDeposito(eZona Origen_){
		this.Origen = Origen_;
		this.ClientesAEntregar = new List<cCliente>();
		this.ProductosADespachar = new cProducto.cListaProducto();
		this.Camiones = new List<cVehiculo>();
		this.Mapa = new cZona.cListaZonas();
        CreacionMapa();
	}

	~cDeposito(){ }

	#endregion Constructores y Destructores
   
	#region Funciones de asignacion
    public void AsignarListaProductos(cProducto.cListaProducto Productos){
		this.ProductosADespachar.AgregarLista(Productos);
	}
    public void IgualarListaClientes(List<cCliente> list)
    {
        ClientesAEntregar = list;
    }
 
	public void AsignarListaClientes(List<cCliente> Clientes){
		this.ClientesAEntregar.AddRange(Clientes);
	}

	public void AsignarListaVehiculos(List<cVehiculo> Vehiculos_){
		this.Camiones = Vehiculos_;
	}
	#endregion Funciones de asignacion

    #region Getters
    public List<cVehiculo> Vehiculos{get{return Camiones;}}
    public List<cCliente> Clientes{get{return ClientesAEntregar;}
    set{ClientesAEntregar = value;}}
    public cZona.cListaZonas MapaEntregar{get{return Mapa;}}
    public cProducto.cListaProducto Productos{ get { return ProductosADespachar;}}
    #endregion Setters
	
    public void CreacionMapa()
	{
		#region Zonas
        cZona Liniers = new cZona(eZona.Liniers);
        cZona VicenteLopez = new cZona(eZona.VicenteLopez);
        cZona SanIsidro = new cZona(eZona.SanIsidro);
        cZona GralSanMartin = new cZona(eZona.GeneralSanMartin);
        cZona TresDeFebrero = new cZona(eZona.TresDeFebrero);
        cZona Moron = new cZona(eZona.Moron);
        cZona LaMatanza = new cZona(eZona.LaMatanza);
        cZona LomasDeZamora = new cZona(eZona.LomasDeZamora);
        cZona Lanus = new cZona(eZona.Lanus);
        cZona Avellaneda = new cZona(eZona.Avellaneda);
        cZona Comuna1 = new cZona(eZona.Comuna1);
        cZona Comuna2 = new cZona(eZona.Comuna2);
        cZona Comuna3 = new cZona(eZona.Comuna3);
        cZona Comuna4 = new cZona(eZona.Comuna4);
        cZona Comuna5 = new cZona(eZona.Comuna5);
        cZona Comuna6 = new cZona(eZona.Comuna6);
        cZona Comuna7 = new cZona(eZona.Comuna7);
        cZona Comuna8 = new cZona(eZona.Comuna8);
        cZona Comuna9 = new cZona(eZona.Comuna9);
        cZona Comuna10 = new cZona(eZona.Comuna10);
        cZona Comuna11 = new cZona(eZona.Comuna11);
        cZona Comuna12 = new cZona(eZona.Comuna12);
        cZona Comuna13 = new cZona(eZona.Comuna13);
        cZona Comuna14 = new cZona(eZona.Comuna14);
        cZona Comuna15 = new cZona(eZona.Comuna15);
        #endregion Zonas

		#region Liniers
		Liniers.AddAdyacentes(eZona.TresDeFebrero);
		Liniers.AddAdyacentes(eZona.LaMatanza);
		Liniers.AddAdyacentes(eZona.Comuna8);
        Liniers.AddAdyacentes(eZona.Comuna9);
        Liniers.AddAdyacentes(eZona.Comuna10);
		Liniers.AddDistancias(8.09f);
		Liniers.AddDistancias(5.43f);
		Liniers.AddDistancias(6.28f);
		Liniers.AddDistancias(3.21f);
		Liniers.AddDistancias(2.53f);
		#endregion Liniers
		#region VicenteLopez
		VicenteLopez.AddAdyacentes(eZona.SanIsidro);
		VicenteLopez.AddAdyacentes(eZona.GeneralSanMartin);
		VicenteLopez.AddAdyacentes(eZona.Comuna12);
		VicenteLopez.AddAdyacentes(eZona.Comuna13);
		VicenteLopez.AddDistancias(7.38f);
		VicenteLopez.AddDistancias(8.17f);
		VicenteLopez.AddDistancias(7.49f);
		VicenteLopez.AddDistancias(3.66f);
		#endregion VicenteLopez
		#region SanIsidro
		SanIsidro.AddAdyacentes(eZona.VicenteLopez);
        SanIsidro.AddAdyacentes(eZona.GeneralSanMartin);
		SanIsidro.AddDistancias(7.38f);
        SanIsidro.AddDistancias(9.96f);
		#endregion SanIsidro
		#region GralSanMartin
		GralSanMartin.AddAdyacentes(eZona.VicenteLopez);
		GralSanMartin.AddAdyacentes(eZona.SanIsidro);
		GralSanMartin.AddAdyacentes(eZona.TresDeFebrero);
		GralSanMartin.AddAdyacentes(eZona.Comuna11);
		GralSanMartin.AddAdyacentes(eZona.Comuna12);	
		GralSanMartin.AddDistancias(8.17f);
		GralSanMartin.AddDistancias(9.96f);
		GralSanMartin.AddDistancias(4.54f);
		GralSanMartin.AddDistancias(4.77f);
		GralSanMartin.AddDistancias(4.44f);
		#endregion GralSanMartin
		#region TresDeFebrero
		TresDeFebrero.AddAdyacentes(eZona.Liniers);
		TresDeFebrero.AddAdyacentes(eZona.GeneralSanMartin);
		TresDeFebrero.AddAdyacentes(eZona.Moron);
		TresDeFebrero.AddAdyacentes(eZona.LaMatanza);
		TresDeFebrero.AddAdyacentes(eZona.Comuna10);
		TresDeFebrero.AddAdyacentes(eZona.Comuna11);
		TresDeFebrero.AddDistancias(8.09f);
		TresDeFebrero.AddDistancias(4.54f);
		TresDeFebrero.AddDistancias(8.31f);
		TresDeFebrero.AddDistancias(9.42f);
	    TresDeFebrero.AddDistancias(8.43f);
		TresDeFebrero.AddDistancias(8.02f);
		#endregion TresDeFebrero
		#region Moron
		Moron.AddAdyacentes(eZona.TresDeFebrero);
		Moron.AddAdyacentes(eZona.LaMatanza);
		Moron.AddDistancias(8.31f);
		Moron.AddDistancias(5.54f);
		#endregion Moron
		#region LaMatanza
		LaMatanza.AddAdyacentes(eZona.Liniers);
		LaMatanza.AddAdyacentes(eZona.TresDeFebrero);
		LaMatanza.AddAdyacentes(eZona.Moron);
		LaMatanza.AddAdyacentes(eZona.LomasDeZamora);
		LaMatanza.AddAdyacentes(eZona.Comuna8);
		LaMatanza.AddAdyacentes(eZona.Comuna9);
		LaMatanza.AddDistancias(5.43f);
		LaMatanza.AddDistancias(9.42f);
		LaMatanza.AddDistancias(5.54f);
		LaMatanza.AddDistancias(17.39f);
		LaMatanza.AddDistancias(9.35f);
		LaMatanza.AddDistancias(5.63f);
		#endregion LaMatanza
		#region LomasDeZamora
		LomasDeZamora.AddAdyacentes(eZona.LaMatanza);
		LomasDeZamora.AddAdyacentes(eZona.Lanus);
		LomasDeZamora.AddAdyacentes(eZona.Comuna8);
		LomasDeZamora.AddDistancias(17.39f);
		LomasDeZamora.AddDistancias(7.5f);
        LomasDeZamora.AddDistancias(10.57f);
		#endregion LomasDeZamora
		#region Lanus
		Lanus.AddAdyacentes(eZona.LomasDeZamora);
		Lanus.AddAdyacentes(eZona.Avellaneda);
		Lanus.AddAdyacentes(eZona.Comuna4);
		Lanus.AddAdyacentes(eZona.Comuna8);
		Lanus.AddDistancias(7.5f);
		Lanus.AddDistancias(5.53f);
		Lanus.AddDistancias(6.42f);
		Lanus.AddDistancias(5.59f);
		#endregion Lanus
		#region Avellaneda
		Avellaneda.AddAdyacentes(eZona.Lanus);
		Avellaneda.AddAdyacentes(eZona.Comuna4);
		Avellaneda.AddDistancias(5.53f);
		Avellaneda.AddDistancias(2.7f);
		#endregion Avellaneda
		#region Comuna1
		Comuna1.AddAdyacentes(eZona.Comuna2);
		Comuna1.AddAdyacentes(eZona.Comuna3);
		Comuna1.AddAdyacentes(eZona.Comuna4);
		Comuna1.AddDistancias(3.24f);
		Comuna1.AddDistancias(3.36f);
		Comuna1.AddDistancias(4.61f);
		#endregion Comuna1
		#region Comuna2
		Comuna2.AddAdyacentes(eZona.Comuna1);
		Comuna2.AddAdyacentes(eZona.Comuna3);
		Comuna2.AddAdyacentes(eZona.Comuna5);
		Comuna2.AddAdyacentes(eZona.Comuna14);
		Comuna2.AddDistancias(3.24f);
		Comuna2.AddDistancias(3.4f);
		Comuna2.AddDistancias(4.04f);
		Comuna2.AddDistancias(3.21f);
		#endregion Comuna2
		#region Comuna3
		Comuna3.AddAdyacentes(eZona.Comuna1);
        Comuna3.AddAdyacentes(eZona.Comuna2);
        Comuna3.AddAdyacentes(eZona.Comuna4);
        Comuna3.AddAdyacentes(eZona.Comuna5);
        Comuna3.AddAdyacentes(eZona.Comuna14);
		Comuna3.AddDistancias(3.36f);
        Comuna3.AddDistancias(3.4f);
        Comuna3.AddDistancias(3.17f);
        Comuna3.AddDistancias(1.83f);
        Comuna3.AddDistancias(5.23f);

        #endregion Comuna3
        #region Comuna4
        Comuna4.AddAdyacentes(eZona.Lanus);
        Comuna4.AddAdyacentes(eZona.Avellaneda);
        Comuna4.AddAdyacentes(eZona.Comuna1);
        Comuna4.AddAdyacentes(eZona.Comuna3);
        Comuna4.AddAdyacentes(eZona.Comuna5);
        Comuna4.AddAdyacentes(eZona.Comuna7);
        Comuna4.AddAdyacentes(eZona.Comuna8);
		Comuna4.AddDistancias(6.42f);
        Comuna4.AddDistancias(2.7f);
        Comuna4.AddDistancias(4.61f);
        Comuna4.AddDistancias(3.17f);
        Comuna4.AddDistancias(4.32f);
        Comuna4.AddDistancias(5.27f);
        Comuna4.AddDistancias(6.33f);
        #endregion Comuna4
        #region Comuna5
        Comuna5.AddAdyacentes(eZona.Comuna2);
        Comuna5.AddAdyacentes(eZona.Comuna3);
        Comuna5.AddAdyacentes(eZona.Comuna4);
        Comuna5.AddAdyacentes(eZona.Comuna6);
        Comuna5.AddAdyacentes(eZona.Comuna7);
        Comuna5.AddAdyacentes(eZona.Comuna14);
        Comuna5.AddAdyacentes(eZona.Comuna15);
        Comuna5.AddDistancias(4.04f);
        Comuna5.AddDistancias(1.83f);
        Comuna5.AddDistancias(4.32f);
        Comuna5.AddDistancias(2.41f);
        Comuna5.AddDistancias(3.63f);
        Comuna5.AddDistancias(4.59f);
        Comuna5.AddDistancias(4.17f);

        #endregion Comuna5
        #region Comuna6
        Comuna6.AddAdyacentes(eZona.Comuna5);
        Comuna6.AddAdyacentes(eZona.Comuna7);
        Comuna6.AddAdyacentes(eZona.Comuna11);
        Comuna6.AddAdyacentes(eZona.Comuna15);
        Comuna6.AddDistancias(2.41f);
        Comuna6.AddDistancias(2.22f);
        Comuna6.AddDistancias(6.37f);
        Comuna6.AddDistancias(3.12f);
        #endregion Comuna6
        #region Comuna7
        Comuna7.AddAdyacentes(eZona.Comuna4);
        Comuna7.AddAdyacentes(eZona.Comuna5);
        Comuna7.AddAdyacentes(eZona.Comuna6);
        Comuna7.AddAdyacentes(eZona.Comuna8);
        Comuna7.AddAdyacentes(eZona.Comuna9);
        Comuna7.AddAdyacentes(eZona.Comuna10);
        Comuna7.AddAdyacentes(eZona.Comuna11);
        Comuna7.AddDistancias(5.27f);
        Comuna7.AddDistancias(3.63f);
        Comuna7.AddDistancias(2.22f);
        Comuna7.AddDistancias(3.03f);
        Comuna7.AddDistancias(5.55f);
        Comuna7.AddDistancias(5.47f);
        Comuna7.AddDistancias(7.13f);
        #endregion Comuna7
        #region Comuna8
        Comuna8.AddAdyacentes(eZona.LaMatanza);
        Comuna8.AddAdyacentes(eZona.LomasDeZamora);
        Comuna8.AddAdyacentes(eZona.Lanus);
        Comuna8.AddAdyacentes(eZona.Comuna4);
        Comuna8.AddAdyacentes(eZona.Comuna7);
        Comuna8.AddAdyacentes(eZona.Comuna9);
        Comuna8.AddDistancias(9.35f);
        Comuna8.AddDistancias(10.57f);
        Comuna8.AddDistancias(5.59f);
        Comuna8.AddDistancias(6.33f);
        Comuna8.AddDistancias(3.03f);
        Comuna8.AddDistancias(4.96f);
        #endregion Comuna8
        #region Comuna9
        Comuna9.AddAdyacentes(eZona.Liniers);
        Comuna9.AddAdyacentes(eZona.LaMatanza);
        Comuna9.AddAdyacentes(eZona.Comuna7);
        Comuna9.AddAdyacentes(eZona.Comuna8);
        Comuna9.AddAdyacentes(eZona.Comuna10);
        Comuna9.AddDistancias(3.21f);
        Comuna9.AddDistancias(5.63f);
        Comuna9.AddDistancias(5.55f);
        Comuna9.AddDistancias(4.96f);
        Comuna9.AddDistancias(3.31f);
        #endregion Comuna9
        #region Comuna10
        Comuna10.AddAdyacentes(eZona.Liniers);
        Comuna10.AddAdyacentes(eZona.TresDeFebrero);
        Comuna10.AddAdyacentes(eZona.Comuna7);
        Comuna10.AddAdyacentes(eZona.Comuna9);
        Comuna10.AddAdyacentes(eZona.Comuna11);
        Comuna10.AddDistancias(2.53f);
        Comuna10.AddDistancias(8.43f);
        Comuna10.AddDistancias(5.47f);
        Comuna10.AddDistancias(3.31f);
        Comuna10.AddDistancias(2.11f);
        #endregion Comuna10
        #region Comuna11
        Comuna11.AddAdyacentes(eZona.GeneralSanMartin);
        Comuna11.AddAdyacentes(eZona.TresDeFebrero);
        Comuna11.AddAdyacentes(eZona.Comuna6);
        Comuna11.AddAdyacentes(eZona.Comuna7);
        Comuna11.AddAdyacentes(eZona.Comuna10);
        Comuna11.AddAdyacentes(eZona.Comuna12);
        Comuna11.AddAdyacentes(eZona.Comuna15);
        Comuna11.AddDistancias(4.77f);
        Comuna11.AddDistancias(8.02f);
        Comuna11.AddDistancias(6.37f);
        Comuna11.AddDistancias(7.13f);
        Comuna11.AddDistancias(2.11f);
        Comuna11.AddDistancias(5.57f);
        Comuna11.AddDistancias(5.52f);
        #endregion Comuna11
        #region Comuna12
        Comuna12.AddAdyacentes(eZona.VicenteLopez);
        Comuna12.AddAdyacentes(eZona.GeneralSanMartin);
        Comuna12.AddAdyacentes(eZona.Comuna11);
        Comuna12.AddAdyacentes(eZona.Comuna13);
        Comuna12.AddAdyacentes(eZona.Comuna15);
        Comuna12.AddDistancias(4.79f);
        Comuna12.AddDistancias(4.44f);
        Comuna12.AddDistancias(5.57f);
        Comuna12.AddDistancias(3.35f);
        Comuna12.AddDistancias(4.57f);

        #endregion Comuna12
        #region Comuna13
        Comuna13.AddAdyacentes(eZona.VicenteLopez);
        Comuna13.AddAdyacentes(eZona.Comuna12);
        Comuna13.AddAdyacentes(eZona.Comuna14);
        Comuna13.AddAdyacentes(eZona.Comuna15);
        Comuna13.AddDistancias(3.66f);
        Comuna13.AddDistancias(3.35f);
        Comuna13.AddDistancias(3.86f);
        Comuna13.AddDistancias(4.44f);
        #endregion Comuna13
        #region Comuna14
        Comuna14.AddAdyacentes(eZona.Comuna2);
        Comuna14.AddAdyacentes(eZona.Comuna5);
        Comuna14.AddAdyacentes(eZona.Comuna13);
        Comuna14.AddAdyacentes(eZona.Comuna15);
        Comuna14.AddDistancias(3.21f);
        Comuna14.AddDistancias(4.59f);
        Comuna14.AddDistancias(3.86f);
        Comuna14.AddDistancias(3.83f);
        #endregion Comuna14
        #region Comuna15
        Comuna15.AddAdyacentes(eZona.Comuna5);
        Comuna15.AddAdyacentes(eZona.Comuna6);
        Comuna15.AddAdyacentes(eZona.Comuna11);
        Comuna15.AddAdyacentes(eZona.Comuna12);
        Comuna15.AddAdyacentes(eZona.Comuna13);
        Comuna15.AddAdyacentes(eZona.Comuna14);
        Comuna15.AddDistancias(4.17f);
        Comuna15.AddDistancias(3.12f);
        Comuna15.AddDistancias(5.52f);
        Comuna15.AddDistancias(4.57f);
        Comuna15.AddDistancias(4.44f);
        Comuna15.AddDistancias(3.83f);
        #endregion Comuna15


        #region Agregado al mapa
        Mapa.Agregar(Liniers);
		Mapa.Agregar(VicenteLopez);
        Mapa.Agregar(SanIsidro);
        Mapa.Agregar(GralSanMartin);
        Mapa.Agregar(TresDeFebrero);
        Mapa.Agregar(Moron);
        Mapa.Agregar(LaMatanza);
        Mapa.Agregar(LomasDeZamora);
        Mapa.Agregar(Lanus);
        Mapa.Agregar(Avellaneda);
        Mapa.Agregar(Comuna1);
        Mapa.Agregar(Comuna2);
		Mapa.Agregar(Comuna3);
		Mapa.Agregar(Comuna4);
		Mapa.Agregar(Comuna5);
        Mapa.Agregar(Comuna6);
        Mapa.Agregar(Comuna7);
        Mapa.Agregar(Comuna8);
        Mapa.Agregar(Comuna9);
        Mapa.Agregar(Comuna10);
        Mapa.Agregar(Comuna11);
        Mapa.Agregar(Comuna12);
        Mapa.Agregar(Comuna13);
        Mapa.Agregar(Comuna14);
        Mapa.Agregar(Comuna15);

        #endregion Agregado al mapa

    }
    public void ReiniciarVehiculos()
    { for(int i=0; i<Camiones.Count; i++)
        {
            Camiones[i].Reiniciar();
        }
    }

    /// <summary>
    /// Elige 1 camion que este disponible para realizar envios, verifica si los productos necesitan ascensor o no y llama a ProductosCami�n
    /// Productos camion elige con que se llenar� el cami�n 
    /// </summary>
    public void CargaCamion(ref int n){

        if(!CamionesDisponibles())
            throw new NullReferenceException("No hay vehiculos disponibles para realizar entregas por el dia");

        cProducto.cListaProducto aux = new cProducto.cListaProducto();

            // Recorro la lista de vehiculos en el deposito
            for (int i = 0; i < Camiones.Count; i++)
            {
                if (Camiones[i].RepartosHechos < Camiones[i].RepartosMax)
                {  // Se verifica qué camion tiene envios disponibles
                   // Se verifica que productos pueden enviarse o no (lo del ascensor) y se arma una lista aux

                    for (int j = 0; j < ProductosADespachar.GetCount(); j++)
                    {
                        if (Camiones[i].Ascensor == ProductosADespachar[j].Ascensor || !ProductosADespachar[j].Ascensor)
                        {
                            aux.Agregar(ProductosADespachar[j]);
                        }

                    }
                    if (aux.GetCount() != 0)
                    {
                        n = i;
                        Camiones[i].ElegirProductosCamion(aux);
                        //Camiones[i].RealizarReparto(ClientesAEntregar, Mapa); 
                    }
                    else throw new Exception("No hay productos para repartir en los camiones disponibles");

                    return;
                }
            }     
    }

    #region Funciones para imprimir

    public string To_String_Deposito(){
        string o = "\n---------- DATOS DEL DEPOSITO ----------";

        o +="\nUbicacion:" + Origen.ToString();

        o+= To_String_Camiones();

        o+=To_String_Clientes();

        o+=To_String_Productos();

        return o;
    }
    public string To_String_Clientes(){

        string o ="\n\n--- LISTA DE CLIENTES EN ESPERA DE ENTREGA ---";

        if(ClientesAEntregar.Any())
        {
            int i = 0;
            while(i < ClientesAEntregar.Count){
            o+="\n"+ClientesAEntregar[i].ToString();
            o+= "\n---------------------------------------------\n";
            i++;}
        }
        else {
            o += "\nNo hay clientes en la lista de espera";
        }

		return o;
	}

	public string To_String_Productos(){
        string o = "\n\n--- LISTA DE PRODUCTOS A ENTREGAR ---";
		int i=0;
		if(ProductosADespachar.GetCount() == 0)
        {
            o+="\nNo hay productos en la lista.";
        }
        else{
		    while(i<ProductosADespachar.GetCount())
		    {
			    o+= "\n" + ProductosADespachar[i].ToString();
                o+= "\n---------------------------------------------\n";
			    i++;
		    }
        }
		return o;
	}

	public string To_String_Camiones(){
        string o = "\n\n--- LISTA DE CAMIONES EN EL DEPOSITO ---";
		int i=0;
		if(!Camiones.Any())
        {
            o+="\nNo hay camiones en el deposito";
        }
        else{
		    while(i<Camiones.Count)
		    {
			    o+= Camiones[i].ToString();
                o+= "\n---------------------------------------------\n";
			    i++;
		    }
        }
		return o;
		
	}

	#endregion Funciones para imprimir

	/// <summary>
	/// Verifica si hay camiones con entregas diarias disponibles
	/// </summary>
	/// <returns></returns>
	public bool CamionesDisponibles()
	{
		int cont = 0;

		if (Camiones.Count > 0)
			for (int i = 0; i < Camiones.Count; i++)
				cont += (Camiones[i].RepartosMax - Camiones[i].RepartosHechos);
		
		if (cont != 0)
			return true;
		return false;
	}


}//end cDeposito