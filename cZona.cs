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
    /* internal class cZona
     {
     }*/
    public class cZona
    {
        private eZona Nombre; 
        List<cZona> Adyacentes;
        List<int> Distancias; 


        #region Constructor y destructor
        public cZona(eZona Nombre_)
        {
            this.Nombre = Nombre_;
            this.Adyacentes = new List<cZona>();
            this.Distancias = new List<int>();
        }

        ~cZona()
        {

        }
        #endregion Constructor y destructor

        public eZona Zona { get { return Nombre; } }

        public void AddAdyacentes(List<cZona> Adyacentes)
        { 
            this.Adyacentes.AddRange(Adyacentes); //Agrega toda la lista al final de esta, si tiene algo mas lo mantiene
        } 

        public void AddDistancias(List<int> Distancias) 
        {
            this.Distancias.AddRange(Distancias);
        } 

        public List<cZona> GetAdyacentes()
        {
            return this.Adyacentes;
        }
        public List<int> GetDistancias()
        {
            return this.Distancias;
        }

        public class cListaZonas 
        {
            private List<cZona> Lista;

            #region Constructor y destructor
            public cListaZonas()
            {
                this.Lista = new List<cZona>();
            }

            ~cListaZonas() { }
            #endregion Constructor y destructor 

            #region Getters
            public int GetCount() { return Lista.Count; }

            public cZona GetProduct(int pos) //TODO porq se llama product?
            { 

                if (!Lista.Any() && pos <= Lista.Count()) // Si la lista tiene algo y la posición está dentro de los posibles productos
                    return Lista[pos];
                throw new Exception("No se encuentra"); //no te lo esperabas 
            }
            public cZona GetProduct(eZona nombre) //TODO porq se llama product?
            {

                if (!Lista.Any()) // Si la lista tiene algo y la posición está dentro de los posibles productos
                { int i = 0;
                    while(i<Lista.Count())
                    {
                        if (Lista[i].Zona == nombre) //considerando que no habría forma de q nada sse repita 
                        {
                            return Lista[i];
                        }    
                    }
                }
                throw new Exception("No se encuentra"); //no te lo esperabas 
            }

            public void SetProduct(int pos, cZona nuevo)
            {
                if (nuevo != null && !Lista.Any() && pos <= Lista.Count())
                {
                    Lista[pos] = nuevo;
                }
            }
            // Sobrecarga de [ ] para que devuelva un elemento especifico de la lista
            public cZona this[int pos]
            {
                get => GetProduct(pos);
                set => SetProduct(pos, value);

            }
            #endregion Getters

            #region Modificar lista

            public void Agregar(cZona Nuevo)
            {
                Lista.Add(Nuevo);
            }

            public cZona Quitar(int pos)
            {
                cZona aux = Lista[pos];
                Lista.RemoveAt(pos);
                return aux;
            }

            public void Eliminar(cZona Zona)
            {

                int pos = Lista.IndexOf(Zona);
                Lista.RemoveAt(pos);
            }
            public void Eliminar(int pos)
            {
                Lista.RemoveAt(pos);
            }

            #endregion Modificar lista

        }

    }//end cZona

}


//TODO Todo lo que se modifique por derecha tiene que tener ref adelante
// Dijkstra algorithm with adjacency lists joshua clark
