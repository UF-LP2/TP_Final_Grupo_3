using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class cVehiculo {

	private float Peso_MAX;
	private int Vol_MAX; // Lo hacemos un valor redondo, sin decimal
	private int repartos_dia_max;
	private int repartos_hechos;
	private float consumo_por_km;
	private float consumido;
	private bool ascensor;
	private float alto;
	private cProducto.cListaProducto ProductosAEntregar;
	private List<cCliente> ListaEntregados; 

	//TODO deberiamos imprimir que compre uno nuevo pasados los 4 a�os, no se --> lo dice en la consigna ?? es lo de 25% ?? sep 


	#region Constructores y Destructores

	/// <summary>
	/// Constructor de cVeh�culo
	/// </summary>
	/// <param name="VolumenMAX"></param>
	/// <param name="PesoMAX"></param>
	/// <param name="repartos_max"></param>
	/// <param name="consumo"></param>
	/// <param name="ascensor_"></param>

	public cVehiculo(int VolumenMAX, float PesoMAX, int repartos_max, float consumo, bool ascensor_, float alto_) {

		this.Vol_MAX = VolumenMAX;
		this.Peso_MAX = PesoMAX;
		this.repartos_dia_max = repartos_max;
		this.repartos_hechos = 0;
		this.consumo_por_km = consumo;
		this.consumido = 0;
		this.ascensor = ascensor_;
		this.alto = alto_;
		this.ProductosAEntregar = new cProducto.cListaProducto();
	    this.ListaEntregados = new List<cCliente>(); 

	}

	/// <summary>
	/// Destructor de cVehiculo
	/// </summary>
	~cVehiculo() {

	}

	#endregion Constructores y Destructores

	#region Getters
	public bool Ascensor {

		get{return ascensor;}
	}

	public int RepartosHechos { get { return repartos_hechos; } }
	public int RepartosMax { get { return repartos_dia_max; } }

	public void setRepartosHechos(int cant)
	{
		this.repartos_hechos = cant;
	}
	#endregion Getters

	public void Reiniciar()
	{
		this.repartos_hechos=0;
	}
	#region Funciones para imprimir
	public string TipoVehiculo()
	{
		cVehiculo a =this;
		string o="";
		if(a is cCamioneta)
			o+="CAMIONETA";
		else if(a is cFurgon)
			o+= "FURGON";
		else if(a is cFurgoneta)
			o+= "FURGONETA";
		return o;
	}
	public override string ToString()
	{
		cVehiculo a = this;
		string o = "\n--- DATOS DE ";

		if(a is cCamioneta)
			o+="CAMIONETA ---";
		else if(a is cFurgon)
			o+= "FURGON ---";
		else if(a is cFurgoneta)
			o+= "FURGONETA ---";
		o+= "\nVolumen de carga maxima: " + Vol_MAX.ToString();
		o+= "\nPeso de carga maximo: " + Peso_MAX.ToString();
		o+= "\nRepartos del dia maximo: " + repartos_dia_max.ToString();
		o+= "\nConsumo por km: " + consumo_por_km.ToString();
		o+= "\nLitros consumidos en el dia: " + consumido.ToString();
		o+="\nCuenta con ascensor: " + (ascensor?"si":"no");

		o+= "\n\n--- ENTREGAS REALIZADAS";
		if(ListaEntregados.Any())
		{
			int i = 0;
			while(i<ListaEntregados.Count)
			{
				o+=ListaEntregados[i].ToString();
				i++;
			}
		}
		else{
			o+="\nNo se realizaron entregas hasta el momento";
		}

		o += "\n\n--- ENTREGAS RESTANTES";
		
		if(ProductosAEntregar.GetCount() > 0)
		{
            int j = 0;
			while (j < ProductosAEntregar.GetCount())
			{
				o += ProductosAEntregar[j].ToString();
				j++;
			}
		}
		else
		{
			o += "\nNo hay productos para entregar";
		}
		return o;
	}

    #endregion Funciones para imprimir

    #region Eleccion y entrega de productos

    /// <summary>
    /// Elige los productos con los que se llenar� el cami�n
    ///</summary
    /// <param name="vol_ind"></param>
    /// <param name="Peso"></param>
    /// <param name="n"></param>

    public void ElegirProductosCamion(cProducto.cListaProducto ProductosADespachar) //TODO: probar apenas armamos main; chequear buen uso de casteo, o si el volumen deberia ser int para evitarlo
	{
		int n = ProductosADespachar.GetCount();
		int i, j; //i recorre el peso, j recorre el volumen 

		float[,] matriz = new float[n+1, this.Vol_MAX+1];

		float[] vol_ind = ProductosADespachar.ObtenerVolumenes(alto);
		float[] Pesos = ProductosADespachar.ObtenerPesos();

		float vol = 0;
		bool flag;

		for (i = 0; i < n+1; i++)
		{
			flag = false;
			for (j = 0; j < this.Vol_MAX+1; j++)
			{
				if (i == 0 || j == 0)
				{
					matriz[i, j] = 0;
				}
				else if (vol_ind[i - 1] <= j && vol + vol_ind[i-1] <= Vol_MAX )
				{
					if (flag == false)
					{
						vol += vol_ind[i - 1];
						flag = true;
					}
					
					matriz[i, j] = Math.Max(Pesos[i - 1] + matriz[i - 1, j - (int)(vol_ind[i - 1])], matriz[i - 1, j]);
				}
				else
				{
					matriz[i, j] = matriz[i - 1, j];
				}
			}
		}

		float res = matriz[n, Vol_MAX];
		float Peso_temp = matriz[n, Vol_MAX];
		j = Vol_MAX;

        for (i = n; i > 0 && j > 0; i--)
        {
            if (matriz[i,j] != matriz[i - 1, j])
            {

                ProductosAEntregar.Agregar(ProductosADespachar.Quitar(i - 1));

                //res -= Pesos[i - 1];
                j -= (int)(vol_ind[i - 1]);
            }
        }
        /*
		for (i = n; i > 0 && res > 0; i--)
		{
			if (res != matriz[i - 1, j])
			{

				ProductosAEntregar.Agregar(ProductosADespachar.Quitar(i - 1));

				res -= Pesos[i - 1];
				j -= (int)(vol_ind[i - 1]);
			}
		}*/
        ProductosAEntregar.OrdenarPorPrioridadYPeso();
		VerificarPesoMax();
		

		// Elimino los elementos de la lista del dep�sito
		for (int h = 0; h < ProductosAEntregar.GetCount(); h++)
		{
			ProductosADespachar.EliminarElemento(ProductosAEntregar[h]);
		}
	}

	
	/// <summary>
	/// Llama a  BuscarCamino, y realiza la entrega de los productos a los clientes, contando lo consumido en cada entrega
	/// </summary>
	public void RealizarReparto(ref List<cCliente> ClienteAEntregar, cZona.cListaZonas Mapa, ref List<eZona> Recorrido) {

		BuscarCamino(Mapa, ref Recorrido); //ordena la lista de productos en orden de entrega y busca el camino

		eZona Zona_anterior = ProductosAEntregar[0].Zona;
		eZona Zona_nueva;
		
		while(ProductosAEntregar.GetCount()>0 && ClienteAEntregar.Count > 0)
		{	Zona_nueva = ProductosAEntregar.GetZonaPos(0);
			if(Zona_anterior != Zona_nueva)
			{
				consumido += (Mapa[(int)Zona_anterior].DistanciaAZona(Zona_nueva) * consumo_por_km);
			}
			Zona_anterior = Zona_nueva;
			Entregar(ProductosAEntregar[0], ref ClienteAEntregar);
			
		}


		//despues de la entrega se cuenta como un reparto mas hecho 
		setRepartosHechos(RepartosHechos+1);
	}

    /// <summary>
    /// Le entrega el producto al cliente (Lo asigna a su lista
    /// </summary>
    /// <param name="Entrega"></param>
    /// <param name="ClientesAEntregar"></param>
    public void Entregar(cProducto Entrega, ref List<cCliente> ClientesAEntregar)
    {   
		int pos = ClientesAEntregar.FindIndex(x => x.codigodeoperacion==Entrega.codigodeoperacion); 
        if (pos != -1) // Si hay elementos en la lista y recib� un producto
        {
		
            int aux =0;
                    ClientesAEntregar[pos].Recibir(Entrega); // Le entrego el producto al cliente
                    ProductosAEntregar.EliminarElemento(Entrega); // Elimino la referencia al producto en la lista del camion
					int Codigo = ClientesAEntregar[pos].codigodeoperacion;
					aux= ListaEntregados.IndexOf(ClientesAEntregar[pos]);
                    if (aux==-1)
                        ListaEntregados.Add(ClientesAEntregar[pos]); // Lista con los clientes a los que se les entregaron productos
					if(ClientesAEntregar[pos].CantidadProductos == ClientesAEntregar[pos].CantidadRecibidos)
						ClientesAEntregar.RemoveAt(pos);
                  
            

        }
    }

    #endregion Eleccion y entrega de productos

    #region Busqueda de camino

    /// <summary>
    /// Busca el camino m�s eficiente, y ordena la lista en orden de entrega
    /// </summary>
    void BuscarCamino(cZona.cListaZonas Mapa, ref List<eZona> Recorrido)
	{
		List<eZona> ZonasARecorrer = new List<eZona>();
        List<eZona> ZonasRecorridas = new List<eZona>();
		cProducto.cListaProducto Ordenada = new cProducto.cListaProducto();

        // Copio todas las zonas que tengo en una lista de zonas a recorrer
        ZonasARecorrer = ProductosAEntregar.CopiarZonasARecorrer();
		ZonasRecorridas.Add(eZona.Liniers);
		int k = ZonasARecorrer.IndexOf(eZona.Liniers);
		if(k != -1)
		ZonasARecorrer.RemoveAt(ZonasARecorrer.IndexOf(eZona.Liniers));

		eZona zona_actual = eZona.Liniers;
        eZona zona_anterior = eZona.Liniers;
		eZona zona_ultimo = eZona.Liniers;
		List<eZona> ZonasAux = new List<eZona>();
		while(ZonasARecorrer.Any())
		{
			
		
			// Devuelve por izquierda el camino que tuvo que realizar al destino final, y por derecha la zona que era m�s cercana
			ZonasAux = BuscarCaminoCercano(ref zona_actual,ref zona_anterior,ref zona_ultimo, ZonasARecorrer, Mapa);
			
			ZonasRecorridas.AddRange(ZonasAux);

			int pos = ZonasARecorrer.IndexOf(zona_actual);
			if(pos != -1)
			{
				ZonasARecorrer.RemoveAt(pos);
			}
		}

		//int j = 0; //guarda la posici�n de lo ordenado al inicio
		int h = 0;
		int tam = ZonasRecorridas.Count ;

		List<eZona> Copiados = new List<eZona>();
		while(h<tam)
		{
			if (!Copiados.Contains(ZonasRecorridas[h]))
			{ Copiados.Add(ZonasRecorridas[h]);
				for(int i = 0; i < ProductosAEntregar.GetCount(); i++)
				{
					if(ProductosAEntregar[i].Zona == ZonasRecorridas[h])
					{
						Ordenada.Agregar(ProductosAEntregar[i]);
						

					}
				}
			}h++;
		}

		ProductosAEntregar = Ordenada;
		
		Recorrido=ZonasRecorridas;
	
	}


	public List<eZona> BuscarCaminoCercano(ref eZona zona_ahora,ref eZona zona_anterior,ref eZona ultimo, List<eZona> ZonasARecorrer, cZona.cListaZonas Mapa) {
		List<eZona> Camino = new List<eZona>();
        List<eZona> CaminoFinal = new List<eZona>();
        float costo_min = 0;
		bool exito = false;
		eZona zona_actual = zona_ahora;
		eZona zona_aux = zona_actual;
		
		List<eZona> Visitados  = new List<eZona>();

		while(!exito){
		// Recorrido de adyacentes
		for (int i = 0; i < Mapa.GetZona((int)zona_actual).AdyCount; i++) // Recorro los adyacentes de zona_anterior
		{
			// Si el adyacente es una de las zonas que tengo que recorrer
			if (ZonasARecorrer.Contains(Mapa.GetZona((int)zona_actual).Adyacente(i)) && Mapa.GetZona((int)zona_actual).Adyacente(i) != zona_anterior)
			{ 
				List<eZona> Aux = new List<eZona>();
				//List<eZona> Aux = new List<eZona>();
				if (costo_min == 0)
				{
						
					costo_min = Mapa[(int)zona_actual].Distancia(i);
					zona_aux = Mapa[(int)zona_actual].Adyacente(i);
					Aux.Add(zona_aux);
					Camino = Aux;
				}
				else if (Mapa[(int)zona_actual].Distancia(i) < costo_min)
				{
						
					costo_min = Mapa[(int)zona_actual].Distancia(i);
					zona_aux = Mapa[(int)zona_actual].Adyacente(i);
					Aux.Add(zona_aux);
					Camino = Aux;
				}
			}
		}

		if (costo_min != 0) // Si uno de los adyacentes era parte de donde ten�a que entregar
		{
			zona_anterior = zona_actual;
			zona_ahora = zona_aux;
			exito = true;
			ultimo = zona_actual;
		}
		else // No hab�a entregas en ning�n nodo adyacente
		{
			Visitados.Add(zona_anterior);
			eZona MasCercano = Mapa[(int)zona_actual].AdyacenteMasCercano(Visitados); // Elije el m�s cercano que sea distinta a la zona anterior
			if(Visitados.Count > 5)
			{  
				zona_actual = ultimo;
				List<eZona> aux = new List<eZona>();
				aux.Add(Visitados[1]);
				Visitados.Clear();
				MasCercano= Mapa[(int)zona_actual].AdyacenteMasCercano(aux);
			}
			//Camino.Add(MasCercano);
				zona_anterior = zona_actual;
				zona_actual = MasCercano;
			
			
				
		}
		}
		CaminoFinal.AddRange(Visitados);
		CaminoFinal.AddRange(Camino);

		return CaminoFinal;
    }

	#endregion Busqueda de camino

	
	///<summary>
	///Verifica que los productos en la lista no se pase del peso m�x permitido en el cami�n. Elimina elementos de menor prioridad hasta que el peso total este dentro de los valores permitidos
	///</summary>
	public void VerificarPesoMax()
	{
		// Recibe una lista ordenada por:
		// Orden de prioridad: Diferido - Normal - Express (Ascendiente)
		// Orden de peso: mayor a menor (Descendiente)

		float[] Pesos = ProductosAEntregar.ObtenerPesos();

		int tam = Pesos.Count();
		float cont = 0;

		int j = ProductosAEntregar.GetCount() - 1;

		for(int i = 0; i < tam; i++) {
            cont += Pesos[i];
        }

		while (cont > Peso_MAX) { // Elimino los de menor pr�oridad y menor peso (estan al final de la lista) hasta que los productos en el camion respeten el peso MAX permitido

			cont-= Pesos[j];
			ProductosAEntregar.Eliminar(j);
			j--;
		}
		

	}

}//end cVehiculo