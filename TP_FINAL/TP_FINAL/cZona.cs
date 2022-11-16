using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


//TODO Todo lo que se modifique por derecha tiene que tener ref adelante
// Dijkstra algorithm with adjacency lists joshua clark
public class cZona {
	
	private eZona Nombre;

	List<eZona> Adyacentes;
	List<float> Distancias;

    #region Constructores y destructores
    public cZona(eZona Nombre_){
		this.Nombre = Nombre_;
		this.Adyacentes = new List<eZona>();
		this.Distancias = new List<float>();
	}

	~cZona(){}
    #endregion Constructores y destructores

    public eZona AdyacenteMasCercano(List<eZona> zona_anterior)
    {
        float min = 0;
        eZona aux = zona_anterior[0];

       
        for(int i = 0; i < Adyacentes.Count; i++)
        {
            if (min == 0 && !(zona_anterior.Contains(Adyacentes[i])) ) { // Si es el primer valor que estoy guardando de la lista
                min = Distancias[i];
                aux = Adyacentes[i];
            }
            else if (Distancias[i] < min && !(zona_anterior.Contains(Adyacentes[i])))
            {
                min = Distancias[i];
                aux = Adyacentes[i];
            }
        }
        return aux;
    }

    #region Getters

    public int AdyCount { get { return Adyacentes.Count; } }
    public eZona Adyacente(int value) { return Adyacentes[value]; } 
    public float Distancia(int value) { return Distancias[value]; }

    public float DistanciaAZona(eZona nombre)
    {
        for (int i = 0; i < Adyacentes.Count; i++)
        {
            if (Adyacentes[i] == nombre)
                return Distancias[i];
        }
        return 0;
    }

    #endregion Getters

    #region Funciones de inicializacion
    public void AddAdyacentes(eZona Adyacente) {
        Adyacentes.Add(Adyacente);
    }

	public void AddDistancias(float Distancia) {
        Distancias.Add(Distancia);
    }

    #endregion Funciones de inicializacion

    public class cListaZonas {
        private List<cZona> Lista;

        public cListaZonas() {
            this.Lista = new List<cZona>();
        }

        ~cListaZonas() { }

        #region Getters
        public int GetCount() { return Lista.Count; }

        public cZona GetZona(int pos)
        {
            if (pos < Lista.Count) // Si la lista tiene algo y la posici�n est� dentro de los posibles productos
                return Lista[pos];
            throw new Exception("No encontrado");
        }

        public void SetZona(int pos, cZona nuevo)
        {
            if (nuevo != null && !Lista.Any() && pos <= Lista.Count())
            {
                Lista[pos] = nuevo;
            }
        }
        // Sobrecarga de [ ] para que devuelva un elemento especifico de la lista
        public cZona this[int pos]
        {
            get { return Lista[pos];}
            set => SetZona(pos, value);

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