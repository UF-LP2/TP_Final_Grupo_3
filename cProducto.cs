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
    /*  internal class cProducto
      {
      }*/
    public class cProducto
    {

        private eProducto Tipo;
        private cZona ZonaEntrega;
        private eTipoEntrega Entrega;
        private float Peso;
        private float Alto;
        private float Ancho;
        private float Largo;
        private int CodigoDeOperacion;
        private bool Ascensor;

        #region Constructores y Destructores

        /// <summary>
        /// Constructor de cProducto
        /// </summary>
        /// <param name="Tipo_"></param>
        /// <param name="ZonaEntrega_"></param>
        /// <param name="Entrega_"></param>
        /// <param name="Dimensiones_"></param>
        /// <param name="Codigo"></param>
        /// <param name="Ascensor_"></param>
        public cProducto(eProducto Tipo_, cZona ZonaEntrega_, eTipoEntrega Entrega_, dimensiones Dimensiones_, int Codigo, bool Ascensor_)
        {
            this.Tipo = Tipo_;
            this.ZonaEntrega = ZonaEntrega_;
            this.Entrega = Entrega_;
            this.Peso = Dimensiones_.peso;
            this.Alto = Dimensiones_.alto;
            this.Ancho = Dimensiones_.ancho;
            this.Largo = Dimensiones_.largo;
            this.CodigoDeOperacion = Codigo;
            this.Ascensor = Ascensor_;

        }

        /// <summary>
        /// Destructor de cProducto
        /// </summary>
        ~cProducto() { }

        #endregion Constructores y Destructores

        #region Getters y Setters

        public int codigodeoperacion
        {
            get { return CodigoDeOperacion; }
            set { CodigoDeOperacion = value; }
        }
        public bool NecesitaAscensor()
        {
            return Ascensor;
        }

        public eZona Zona { get { return Zona; } }

        #endregion Getters y Setters

        #region Funciones para imprimir

        public override string ToString()
        {
            return base.ToString() + " \n" + Tipo.ToString() + " " + ZonaEntrega.ToString() + " " + Entrega.ToString() + " " + Peso.ToString() + " " + Alto.ToString() + " " + Ancho.ToString() + " " + Largo.ToString() + " " + CodigoDeOperacion.ToString() + " " + Ascensor.ToString() + "\n";
        }

        #endregion Funciones para imprimir

        public class cListaProducto
        {
            private List<cProducto> Lista;

            #region Constructores y Destructores
            public cListaProducto()
            {
                this.Lista = new List<cProducto>();
            }

            ~cListaProducto() { }

            #endregion Constructores y Destructores

            #region Funciones de Ordenamiento

            /// <summary>
            /// Ordena la lista por prioridad (mayor prioridad a menor)
            /// </summary>
            public void OrdenarPorPrioridad()
            {
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

            /// <summary>
            /// Calcula los volumenes de los productos, los volumenes de los televisores los calcula con la altura del camión
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
                        Volumenes[i] = altura_camion * Lista[i].Ancho * Lista[i].Largo; // Calculo el volumen con el alto del camion, ya que no puede haber otros productos encima
                    }
                    else // Si no
                    {
                        Volumenes[i] = Lista[i].Alto * Lista[i].Ancho * Lista[i].Largo; // Calculo el volumen con sus dimensiones
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

            public int GetCount() { return Lista.Count; }

            public cProducto GetProduct(int pos)
            {

                if (!Lista.Any() && pos <= Lista.Count()) // Si la lista tiene algo y la posición está dentro de los posibles productos
                    return Lista[pos];
                return null;
            }

            public void SetProduct(int pos, cProducto nuevo)
            {
                if (nuevo != null && !Lista.Any() && pos <= Lista.Count())
                {
                    Lista[pos] = nuevo;
                }
            }
            // Sobrecarga de [ ] para que devuelva un elemento especifico de la lista
            public cProducto this[int pos]
            {
                get => GetProduct(pos);
                set => SetProduct(pos, value);

            }

            #endregion Getters

            #region Funciones para imprimir

            public override string ToString() //TODO: Probar
            {
                int tam = Lista.Count();
                int i = 0;
                string aux = "";
                while (i < tam)
                {
                    aux += base.ToString(); //creo que va a cada objeto de la lista y usa la funcion
                }
                return aux;
            }

            #endregion Funciones para imprimir

            #region Modificar lista
            public void Agregar(cProducto Nuevo)
            {
                Lista.Add(Nuevo);
            }

            public cProducto Quitar(int pos)
            {
                cProducto aux = Lista[pos];
                Lista.RemoveAt(pos);
                return aux;
            }

            public void Eliminar(cProducto Producto)
            {

                int pos = Lista.IndexOf(Producto);
                Lista.RemoveAt(pos);
            }
            public void Eliminar(int pos)
            {
                Lista.RemoveAt(pos);
            }

            #endregion Modificar lista

            public List<eZona> CopiarZonasARecorrer()
            {
                List<eZona> ListaZonasARecorrer = new List<eZona>();

                for (int i = 0; i < Lista.Count; i++)
                {
                    bool encontrada = false;
                    if (i == 0)
                        ListaZonasARecorrer.Add(Lista[0].Zona);
                    else
                    {
                        for (int h = 0; h < ListaZonasARecorrer.Count; h++)
                        {
                            if (ListaZonasARecorrer[h] == Lista[i].Zona)
                                encontrada = true;

                            if (!encontrada)
                                ListaZonasARecorrer.Add(Lista[i].Zona);
                        }
                    }
                }
                return ListaZonasARecorrer;
            }

        }

    }//end cProducto

}




