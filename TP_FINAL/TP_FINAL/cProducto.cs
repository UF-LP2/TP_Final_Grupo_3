using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class cProducto {

    private eProducto Tipo;
	private eZona ZonaEntrega;
	private eTipoEntrega Entrega;
	private float Peso;
	private sDimensiones Dimensiones;
	private int CodigoDeOperacion;
	private bool NecesitaAscensor;

	# region Constructores y Destructores

	/// <summary>
	/// Constructor de cProducto
	/// </summary>
	/// <param name="Tipo_"></param>
	/// <param name="ZonaEntrega_"></param>
	/// <param name="Entrega_"></param>
	/// <param name="Peso_"></param>
	/// <param name="dimensiones_.alto"></param>
	/// <param name="dimensiones_.ancho"></param>
	/// <param name="dimensiones_.largo"></param>
	/// <param name="Codigo"></param>
	/// <param name="Ascensor_"></param>
	
	public cProducto(eProducto Tipo_, eZona ZonaEntrega_, eTipoEntrega Entrega_, float Peso_, sDimensiones dimensiones_, int Codigo, bool Ascensor_){
		this.Tipo = Tipo_;
		this.ZonaEntrega = ZonaEntrega_;
		this.Entrega = Entrega_;
		this.Peso=Peso_;
		this.Dimensiones = dimensiones_;
		this.CodigoDeOperacion = Codigo;
		this.NecesitaAscensor = Ascensor_;
	}

	/// <summary>
	/// Destructor de cProducto
	/// </summary>
	~cProducto(){ }

    #endregion Constructores y Destructores

    #region Getters y Setters

    public int codigodeoperacion {
		get { return CodigoDeOperacion; }
		set { CodigoDeOperacion = value; }
	}

	public eZona Zona { get { return ZonaEntrega; } }

	public bool Ascensor { get { return NecesitaAscensor; } }

    #endregion Getters y Setters

    #region Funciones para imprimir

    public override string ToString()
	{
		string o ="\n\n--- PRODUCTO CODIGO "+ codigodeoperacion.ToString() ;

		cProducto a = this;

		if(a is cElectronicos)
			o+= "\nCategoria: Electronicos";
		else if(a is cLineaBlanca)
			o+= "\nCategoria: Linea Blanca";
		else if(a is cPequeniosElect)
			o+= "\nCategoria: Pequenios Electrodomesticos";
		else if(a is cTelevisor)
			o+= "\nCategoria: Televisores";
		
		o+="\nProducto: " + Tipo.ToString();
		o+="\nTipo de entrega: " + Entrega.ToString();
		o+="\nPeso: " + Peso.ToString() + " kg";
		o+="\nDimensiones: " + Dimensiones.alto + " m x " + Dimensiones.ancho + " m x " + Dimensiones.largo + " m";
		o+="\nNecesita ascensor: " + (Ascensor? "si":"no");
		return o;}

    #endregion Funciones para imprimir
	

    public class cListaProducto
    {
        private List<cProducto> Lista;

        #region Constructores y Destructores
        public cListaProducto() {
			this.Lista = new List<cProducto>(); }

        ~cListaProducto() { }

		#endregion Constructores y Destructores

		#region Funciones de Ordenamiento

		/// <summary>
		/// Ordena la lista por prioridad (mayor prioridad a menor)
		/// </summary>
		public void OrdenarPorPrioridad() {
			Lista = Lista.OrderBy(x => x.Entrega).ToList(); // Ascendiente

			// Express = 0, Normal = 1, Diferido = 2
		}

		/// <summary>
		/// Ordena la lista por prioridad (mayor prioridad a menor) y, sin desordenar la prioridad, ordena por peso (mayor a menor)
		/// </summary>
        public void OrdenarPorPrioridadYPeso() // TODO: verificar que funcione igualado a la lista, o si primero hay que ponerlo en una aux
		{
            // https://www.techiedelight.com/sort-list-in-descending-order-in-csharp/
            // Ordeno la lista por prioridad de entrega y peso
            Lista = Lista.OrderBy(x => x.Entrega).ThenByDescending(x => x.Peso).ToList();

			// Orden de prioridad: Diferido - Normal - Express (Ascendiente)
			// Orden de peso: mayor a menor (Descendiente)

			/*
			for(int i = 0; i < Lista.Count; i++)
			{ 
				if (Lista[i].Entrega == Lista[i + 1].Entrega) 
					Lista.OrderByDescending(x => x.Peso).ToList(); //creo que esto ya lo ordena de forma ascendente , no se si puede hacerlo como en una "sublista"
			}*/

		}

        #endregion Funciones de Ordenamiento

        #region Getters

		public eZona GetZonaPos(int pos){
			return Lista[pos].Zona;
		}
        /// <summary>
        /// Calcula los volumenes de los productos, los volumenes de los televisores los calcula con la altura del cami�n
        /// </summary>
        /// <param name="altura_camion"></param>
        /// <returns></returns>
        public float[] ObtenerVolumenes(float altura_camion)
        {
			float[] Volumenes = new float[Lista.Count]; // Creo un array de floats para almacenar los volumenes de los productos

			for (int i = 0; i < Lista.Count; i++) // Recorro la lista
			{
				if (Lista[i].Tipo == eProducto.Televisor) // Si el producto es un televisor
				{
					Volumenes[i] = altura_camion * Lista[i].Dimensiones.ancho * Lista[i].Dimensiones.largo; // Calculo el volumen con el alto del camion, ya que no puede haber otros productos encima
				}
				else // Si no
				{
					Volumenes[i] = Lista[i].Dimensiones.alto * Lista[i].Dimensiones.ancho * Lista[i].Dimensiones.largo; // Calculo el volumen con sus dimensiones
				}
			}
            return Volumenes; // Devuelvo la lista
        }

		/// <summary>
		/// Obtiene el peso de todos los productos en la lista
		/// </summary>
		/// <returns></returns>
        public float[] ObtenerPesos()
        {
            float[] Pesos = new float[Lista.Count]; // Creo un array de floats para almacenar los volumenes de los productos

            for (int i = 0; i < Lista.Count; i++) // Recorro la lista
            {
				Pesos[i] = Lista[i].Peso;
            }
            return Pesos; // Devuelvo la lista
        }

		public float VolumenTotal()
		{
			float total = 0;

			float[] lista = ObtenerVolumenes(2.345f);
			for (int i = 0; i < lista.Length; i++)
				total += lista[i];

			return total;
		}

		public int GetCount() { return Lista.Count; }

		public cProducto GetProduct(int pos) { 

			if(Lista.Any() && pos <= Lista.Count) // Si la lista tiene algo y la posici�n est� dentro de los posibles productos
				return Lista[pos];
			throw new Exception("No encontrado");
		}

		public void SetProduct(int pos, cProducto nuevo)
		{
			if(nuevo != null && !Lista.Any() && pos <= Lista.Count())
			{
				Lista[pos] = nuevo;
			}
		}
		// Sobrecarga de [ ] para que devuelva un elemento especifico de la lista
		public cProducto this [int pos]
		{
			get {return Lista[pos];}
			set => SetProduct(pos, value);

		}


		#endregion Getters

		#region Funciones para imprimir

		public override string ToString() //TODO: Probar
		{
			int tam = Lista.Count(); 
			int i=0;
			string aux="";
			while (i < tam)
			{
				aux+=base.ToString(); //creo que va a cada objeto de la lista y usa la funcion
			}
			return aux;
		}

        #endregion Funciones para imprimir

        #region Modificar lista
        public void Agregar(cProducto Nuevo)
		{
			Lista.Add(Nuevo);
		}

		public void AgregarLista(cProducto.cListaProducto prod){
			Lista.AddRange(prod.Lista);
		}
		public cProducto Quitar(int pos) {
			cProducto aux = Lista[pos];
			//Lista.RemoveAt(pos);
			return aux; 
		}

		public void EliminarElemento(cProducto Producto) {

			int pos = Lista.IndexOf(Producto);
			Lista.RemoveAt(pos);
		}
		public void Eliminar(int pos)
		{
			Lista.RemoveAt(pos);
		}
		public void Cambiar( cProducto eliminar, cProducto cambiar)
		{
			int pos = Lista.IndexOf(eliminar);
			int pos1 = Lista.IndexOf(cambiar);
			if (pos != -1) 
			{ 
				//Lista.RemoveAt(pos);
				//Lista.Remove(eliminar);
				Lista[pos] = cambiar;
				Lista[pos1] = eliminar;
				
			}
			
		}
		

        #endregion Modificar lista

        public List<eZona> CopiarZonasARecorrer()
		{
            List<eZona> ListaZonasARecorrer = new List<eZona>();
	
 			for(int i=0; i<Lista.Count; i++)
			{
				if(i == 0)
					ListaZonasARecorrer.Add(Lista[0].Zona);
				else
				{
					int pos = ListaZonasARecorrer.IndexOf(Lista[i].Zona);
					if (pos == -1)
						ListaZonasARecorrer.Add(Lista[i].Zona);
						
				}
			}
			return ListaZonasARecorrer;
		}

        public void ActualizarPrioridades()
        {
            for(int i = 0; i < Lista.Count; i++)
			{
				if(Lista[i].Entrega == eTipoEntrega.Normal)
				{
					Lista[i].Entrega = eTipoEntrega.Express;
				}
				else if(Lista[i].Entrega == eTipoEntrega.Diferido)
				Lista[i].Entrega = eTipoEntrega.Normal;
			}
        }
    }

}//end cProducto