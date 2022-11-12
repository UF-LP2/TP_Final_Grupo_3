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
    /* internal class cVehiculo
     {
     }*/
    public abstract class cVehiculo
    {

        private float Peso_MAX;
        private int Vol_MAX; // Lo hacemos un valor redondo, sin decimal
        private int repartos_dia_max;
        private int repartos_realizados;
        private int repartos_hechos;
        private float consumo_por_km;
        private float consumido;
        private bool ascensor;
        private float alto;
        private cProducto.cListaProducto ProductosAEntregar;


        //TODO deberiamos imprimir que compre uno nuevo pasados los 4 años, no se --> lo dice en la consigna ?? es lo de 25% ?? sep 


        #region Constructores y Destructores

        /// <summary>
        /// Constructor de cVehículo
        /// </summary>
        /// <param name="VolumenMAX"></param>
        /// <param name="PesoMAX"></param>
        /// <param name="repartos_max"></param>
        /// <param name="consumo"></param>
        /// <param name="ascensor_"></param>

        public cVehiculo(int VolumenMAX, float PesoMAX, int repartos_max, float consumo, bool ascensor_, float alto_)
        {

            this.Vol_MAX = VolumenMAX;
            this.Peso_MAX = PesoMAX;
            this.repartos_dia_max = repartos_max;
            this.consumido = consumo;
            this.ascensor = ascensor_;
            this.alto = alto_;
            this.ProductosAEntregar = new cProducto.cListaProducto();

        }

        /// <summary>
        /// Destructor de cVehiculo
        /// </summary>
        ~cVehiculo()
        {

        }

        #endregion Constructores y Destructores

        #region Getters
        public bool TieneAscensor()
        {

            return ascensor;
        }

        public int ViajesMax()
        {
            return repartos_dia_max;
        }

        public int RepartosHechos()
        {
            return repartos_hechos;
        }
        #endregion Getters

        #region Funciones para imprimir
        public override string ToString()
        {
            return base.ToString() + " " + Vol_MAX.ToString() + " " + Peso_MAX.ToString() + " " + repartos_dia_max.ToString() + " " + consumido.ToString() + " " + ascensor.ToString() + " ";
        }

        #endregion Funciones para imprimir

        /// <summary>
        /// Elige los productos con los que se llenará el camión
        ///</summary
        /// <param name="vol_ind"></param>
        /// <param name="Peso"></param>
        /// <param name="n"></param>

        public void ProductosCamion(cProducto.cListaProducto ProductosADespachar, int n) //TODO: probar apenas armamos main; chequear buen uso de casteo, o si el volumen deberia ser int para evitarlo
        {
            int i, j; //i recorre el peso, j recorre el volumen 

            float[,] matriz = new float[n + 1, this.Vol_MAX + 1];

            float[] vol_ind = ProductosADespachar.ObtenerVolumenes(alto);
            float[] Pesos = ProductosADespachar.ObtenerPesos();



            for (i = 0; i < n; i++)
            {
                for (j = 0; j < this.Vol_MAX; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        matriz[i, j] = 0;
                    }
                    else if (vol_ind[i - 1] <= j)
                    {
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

            for (i = n; i > 0 && res > 0; i--)
            {
                if (res != matriz[i - 1, j])
                {

                    ProductosAEntregar.Agregar(ProductosADespachar.Quitar(i - 1));

                    res -= Pesos[i - 1];
                    j -= (int)(vol_ind[i - 1]);
                }
            }
            ProductosAEntregar.OrdenarPorPrioridadYPeso();
            VerificarPesoMax();


            // Elimino los elementos de la lista del depósito
            for (int h = 0; h < ProductosAEntregar.GetCount(); h++)
            {
                ProductosADespachar.Eliminar(ProductosAEntregar[h]);
            }


        }


        //TODO: revisar que entregue a la vez todo lo del mismo cliente
        /// <summary>
        /// Llama a  BuscarCamino, y realiza la entrega de los productos a los clientes, contando lo consumido en cada entrega
        /// </summary>
        public void RealizarReparto(List<cCliente> ClientesAEntregar, cZona.cListaZonas Mapa)
        {

            BuscarCamino(Mapa); //ordena la lista de productos en orden de entrega y busca el camino

            int tam = ProductosAEntregar.GetCount();

            for (int i = 0; i < tam; i++)
            {
                Entregar(ProductosAEntregar[i], ClientesAEntregar);
            }
        }


        /// <summary>
        /// Busca el camino más eficiente, y ordena la lista en orden de entrega
        /// </summary>
        void BuscarCamino(cZona.cListaZonas Mapa)
        {
            List<eZona> ZonasARecorrer = new List<eZona>();
            List<eZona> ZonasRecorridas = new List<eZona>();

            // Copio todas las zonas que tengo en una lista de zonas a recorrer
            ZonasARecorrer = ProductosAEntregar.CopiarZonasARecorrer();

            int j = 0; //guarda la posición de lo ordenado al inicio

            for (int i = 0; i < ProductosAEntregar.GetCount(); i++)
            {
                if (ProductosAEntregar[i].Zona == eZona.Liniers)
                {
                    cProducto aux = ProductosAEntregar[j];
                    ProductosAEntregar[j] = ProductosAEntregar[i];
                    ProductosAEntregar[i] = aux;
                    j++;
                }
            }
            //para que quede liniers adelante porque es la central 
            ZonasRecorridas.Add(eZona.Liniers);

            eZona zona_actual = eZona.Liniers;


            while (j < ProductosAEntregar.GetCount())
            {

                List<eZona> ZonasAux = new List<eZona>();

                // TODO Devuelve por izquierda el camino que tuvo que realizar al destino final, y por derecha la zona que era más cercana, le padaría la zona salida y devolvería zona actual orq sino dentro de la funcion no sabes de donde tenes q buscar 
                ZonasAux = BuscarCaminoCercano(ref zona_actual, ZonasARecorrer, Mapa);

                foreach (eZona zona in ZonasAux)
                {
                    ZonasRecorridas.Add(zona);
                }


                // Repetir el primer for para la zona actual
                for (int i = 0; i < ProductosAEntregar.GetCount(); i++)
                {
                    if (ProductosAEntregar[i].Zona == zona_actual)
                    {
                        cProducto aux = ProductosAEntregar[j];
                        ProductosAEntregar[j] = ProductosAEntregar[i];
                        ProductosAEntregar[i] = aux;
                        j++;

                    }
                }

                ZonasARecorrer.Remove(zona_actual);
                //zona_anterior = zona_actual;
            }

        }



        public List<float> Distancia(List<eZona> adyacentes, cZona Zona)
        {
            List<float> Distancia = new List<float>();

            for (int i = 0; i < Zona.ListaAdyacentes.Count; i++)
            {
                for (int j = 0; j < adyacentes.Count; j++)
                {
                    if (Zona.Adyacente(i).Zona == adyacentes[j])
                    {
                        Distancia.Add(Zona.AdyDistancia(j)); //copia a la lista los nombres de las zonas adyacentes de entre donde vas a salir y el resto del recorrido

                    }
                }
            }
            return Distancia;
        }

        public List<eZona> BuscarCaminoCercano(ref eZona zona_actual, List<eZona> ZonasARecorrer, cZona.cListaZonas Mapa)
        {
            List<eZona> Camino = new List<eZona>();

            eZona zona_anterior = zona_actual;


            
            return Camino;
        }


        public List<eZona> Dijkstra(ref float costo, eZona origen, eZona destino, cZona.cListaZonas Mapa)
        {
            List<eZona> Camino = new List<eZona>();

            // Si es desde Liniers, lo agrego al principio del camino,
            // si no, ya está como final del camino anterior

            // Ver el articulo que nos mostro sol (nombre arriba de todo en czona)


            // Si alguno de los adyacentes es el destino, lo agrego al camino, cuento su costo y lo retorno

            // Si ninguno de los adyacentes es el destino, me muevo al adyacente más cercano, lo agrego al camino, y lo vuelvo a buscar


            for (int i = 0; i < Mapa[(int)origen].ListaAdyacentes.Count; i++)
            {


            }


            /*List<eZona> Camino = new List<eZona>();
            Camino.Add(zona_actual);
            List<eZona> adyacentes = new List<eZona>();
            List<float> distancias = new List<float>();

            
            for(int i=0; i < Mapa[(int)zona_anterior].GetAdyacentes().Count; i++)
            {
                for(int j=0;j<ZonasARecorrer.Count();j++)
                {
                    if (zona_anterior.GetAdyacentes()[i].Zona == ZonasARecorrer[j])
                    {
                        adyacentes.Add(ZonasARecorrer[j]); //copia a la lista los nombres de las zonas adyacentes de entre donde vas a salir y el resto del recorrido
                       
                    }
                }
            }

            distancias = Distancia(adyacentes, zona_salida);

            int MinDistPos = 0;
            if(!adyacentes.Any())
            {
                for(int k=0; k<adyacentes.Count(); k++)
                {
                    if (distancias[k] > MinDistPos)
                        MinDistPos = k;
                    
                }
                zona_actual = adyacentes[MinDistPos];
                Camino.Add(zona_actual);
            }
            else
            {
                //no tiene adyacentes 
                //TODO creo que seria mejor hacer una struct con los nombres de sus adyacentes y sus distancias y por otro lado sus distancias con todo lo demas porque no entiendo,
                //osea habria que ver cuales son los adyacentes que tienen en comun y despues definir el camino y tenerlo asi separado me esta rompiendo el cerebro 

            }
           

            //TODO por adyacencias 
           */

            return Camino;

        }


        /// <summary>
        /// Le entrega el producto al cliente (Lo asigna a su lista
        /// </summary>
        /// <param name="Entrega"></param>
        /// <param name="ClientesAEntregar"></param>
        public void Entregar(cProducto Entrega, List<cCliente> ClientesAEntregar)
        {

            //TODO:  pienso en un while con un bool si lo pudo entregar para que salga--> ahi lo puse con un while pero no se  

            if (!ClientesAEntregar.Any() && Entrega != null) // Si hay elementos en la lista y recibí un producto
            {
                for (int i = 0; i < ClientesAEntregar.Count(); i++) // Recorro la lista de clientes
                {
                    if (ClientesAEntregar[i] != null && ClientesAEntregar[i].codigodeoperacion == Entrega.codigodeoperacion) // Si encontré el cliente que lo compró

                    {
                        ClientesAEntregar[i].Recibir(Entrega); // Le entrego el producto al cliente
                        ProductosAEntregar.Eliminar(Entrega); // Elimino la referencia al producto en la lista del camion
                        break;
                    }
                }

            }


           /* if (!ClientesAEntregar.Any() && Entrega != null) // Si hay elementos en la lista y recibí un producto
            {
                int i = 0; 
                while(i<ClientesAEntregar.Count() && ClientesAEntregar[i].codigodeoperacion == Entrega.codigodeoperacion)
                 // Recorro la lista de clientes
                {
                    if (ClientesAEntregar[i] != null ) // Si encontré el cliente que lo compró
                    {
                        ClientesAEntregar[i].Recibir(Entrega); // Le entrego el producto al cliente
                        ProductosAEntregar.Eliminar(Entrega); // Elimino la referencia al producto en la lista del camion
                        
                    }
                }
                i++;
            }*/



        }


        ///<summary>
        ///Verifica que los productos en la lista no se pase del peso mï¿½x permitido en el camiï¿½n. Elimina elementos de menor prioridad hasta que el peso total este dentro de los valores permitidos
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

            for (int i = 0; i <= tam; i++)
            {
                cont += Pesos[i];
            }

            while (cont > Peso_MAX)
            { // Elimino los de menor príoridad y menor peso (estan al final de la lista) hasta que los productos en el camion respeten el peso MAX permitido

                cont -= Pesos[j];
                ProductosAEntregar.Eliminar(j);
            }


        }
    }//end cVehiculo


}



