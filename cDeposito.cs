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
    public class cDeposito
    {

        private cZona Origen;
        private List<cCliente> ClientesAEntregar;
        private cProducto.cListaProducto ProductosADespachar;

        private cZona.cListaZonas Mapa;
        private List<cVehiculo> Camiones;


        #region Constructores y Destructores
        /// <param name="Origen"></param>
        public cDeposito(cZona Origen_, cZona.cListaZonas Mapa_)
        {
            this.Origen = Origen_;
            this.ClientesAEntregar = new List<cCliente>();
            this.ProductosADespachar = new cProducto.cListaProducto();
            Mapa= Mapa_;
            this.Camiones = new List<cVehiculo>();
        }

        ~cDeposito() { }

        #endregion Constructores y Destructores

        #region Funciones de asignacion
        public void AsignarListaProductos(cProducto.cListaProducto Productos)
        {
            this.ProductosADespachar = Productos;
            
        }

        public void AsignarListaClientes(List<cCliente> Clientes)
        {
            this.ClientesAEntregar = Clientes; //si no funk aaddrange pero debería funkr 
        }

        public void AsignarListaVehiculos(List<cVehiculo> Vehiculos_)
        {
            this.Camiones = Vehiculos_;
        }
        #endregion Funciones de asignacion

        /// <summary>
        /// Elige que camion esta disponible para realizar env�os, verifica si los productos necesitan ascensor o no y llama a ProductosCami�n
        /// Productos camion elige con que se llenar� el cami�n 
        /// </summary>
        public void CargaCamion()
        {
            //TODO 
            cProducto.cListaProducto aux = new cProducto.cListaProducto();
            for (int i = 0; i < this.Camiones.Count; i++)
            {
                if (Camiones[i].RepartosHechos() < Camiones[i].ViajesMax() && !Camiones[i].TieneAscensor())
                {  // Se verifica qué camion tiene envios disponibles
                   // Se verifica que productos pueden enviarse o no (lo del ascensor) y se arma una lista aux

                    for (int j = 0; j < this.ProductosADespachar.GetCount(); j++)
                    { 
                        if (!this.ProductosADespachar[j].NecesitaAscensor())
                        {
                            aux.Agregar(this.ProductosADespachar[j]);  //agrega productos q necesitan ascensor 
                        }
                    }
                    Camiones[i].ProductosCamion(aux, n);//TODO n dependería del tamaño de la lista q dependeria del peso,, pero eso lo vemos al final asi q no entiendo como calculariamos eso 
                    //TODO lo unico que tendría logica hacer para mi, es ver que productos necesitan ascensor y pasarselos al camion que tenga y que tenga viajes, porque lo de la prioridad y demas ya estaría hecho de antes 
                }else
                {
                    for (int j = 0; j < this.ProductosADespachar.GetCount(); j++)
                    {
                        if (this.ProductosADespachar[j].NecesitaAscensor())
                        {
                            aux.Agregar(this.ProductosADespachar[j]);
                        }
                    }
                    Camiones[i].ProductosCamion(aux, n);
                }

            }
            
            
          
            // Una vez que se cargó el camión, se eliminan los elementos de su lista de la lista del depósito -->funcion productos camion
            
            /*Adaptando algo asi y chequeando accesos
            for(int h = 0; h < ProductosAEntregar.GetCount(); h++)
            {
                ProductosADespachar.Eliminar(ProductosAEntregar[h]);
            }
            */
        }

        #region Funciones para imprimir
        public string To_String_Clientes()
        {
            int tam = ClientesAEntregar.Count();
            int i = 0;
            string clientes = "Los clientes a repartir son: \n";
            while (i < tam)
            {
                clientes += ClientesAEntregar[i].ToString() + " \n";
                i++;
            }
            return clientes;
        }

        public string To_String_Productos()
        {
            //supongo que en realidad ser�a con la lista asi q solo se llamaria su tostring 
            int tam = ProductosADespachar.GetCount(), i = 0;
            string productos = "Los productos a despachar son: \n";
            while (i < tam)
            {
                productos += ProductosADespachar[i].ToString() + "\n";
                i++;
            }
            return productos;
        }

        public string To_String_Camiones()
        {

            int tam = Camiones.Count(), i = 0;
            string camiones = "Los camiones del dep�sito son: \n";
            while (i < tam)
            {
                camiones += Camiones[i].ToString() + "\n";
                i++;
            }
            return camiones;

        }

        #endregion Funciones para imprimir

    }//end cDeposito
}