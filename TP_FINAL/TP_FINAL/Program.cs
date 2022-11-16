

/*TODO 


--> Revisar inicializacion de listas en clases / constructores
--> No olvidar checkeo de si las listas estan vacias
    bool chk = !lista.Any();
--> Formatear ToStrings
--> Sobrecargas para imprimir
--> Sobregargas para agregar [DONE para la lista de productos]
-->Eliminar clase cZOna y reemplazarla por el enum 
-->En la funcion entregar hay q calcular lo consumido


-->En forms le damos la opcion de iniciar otro dia, si lo elige que actualice las prioridades y reiniciar los caminos que pueden hacer los camiones 
-->Si no podemos hacer una funcion tic y modificar cuanto tiempo pasa con cada ejecucion


 
REVISAR:
cDeposito [DONE]
cVehículo [DONE]
    cCamioneta
    cFurgon
    cFurgoneta
cProducto [DONE]
    cListaProducto
    cElectronicos
    cLineaBlanca
    cPequeniosElec
    cTelevisor
cCliente [DONE]
cZona
enums

 */

using System.Linq.Expressions;


class Cocimundo
{
    public static Random rnd = new Random();
    public static void Main(string[] args)
    {
        #region Creacion del deposito

        Console.WriteLine("~~~ Creando el deposito ~~~");
        Console.WriteLine("DATOS INICIALES DEL DEPOSITO");
        cDeposito Deposito = new cDeposito(eZona.Liniers);
        Console.Write(Deposito.To_String_Deposito());
        Console.WriteLine("\n\n~~~ Presione enter para continuar ~~~");
        Console.ReadLine();
        Console.Clear();

        #endregion Creacion del deposito

        #region Inicializacion Clientes y productos
        Console.WriteLine("~~~ Creando los clientes ~~~");
        Console.WriteLine("~~~ Inicializando sus productos ~~~");

        List<cCliente> ClienteLista = new List<cCliente>();
        cProducto.cListaProducto ListaProductos = new cProducto.cListaProducto();

        ClienteLista = Cocimundo.InicializarClientes(15, ref ListaProductos);

        Deposito.AsignarListaProductos(ListaProductos);
        Deposito.AsignarListaClientes(ClienteLista);

        Console.WriteLine("\n\n~~~ Presione enter para imprimir la lista de clientes y productos actualizada ~~~");
        Console.ReadLine();
        Console.Clear();
        Console.Write(Deposito.To_String_Clientes());
        Console.Write("\n\n~~~ Presione enter para continuar ~~~");
        Console.ReadLine();
        Console.Clear();

        Console.Write(Deposito.To_String_Productos());
        Console.WriteLine("\n\n~~~ Presione enter para continuar ~~~");
        Console.ReadLine();
        Console.Clear();
        #endregion Inicializacion Clientes y productos
   
        #region Vehiculos
        Console.WriteLine("~~~ Creando los vehiculos del deposito ~~~");
        cFurgon Furgon = new cFurgon(10, 4900, 1, 0.08904f , true, 2.345f);
        cFurgoneta Furgoneta = new cFurgoneta(17, 3500, 1, 0.069f , false, 2.254f );
        cCamioneta Camioneta = new cCamioneta(5, 750, 4, 0.086f , false, 1.233f);
        List<cVehiculo> VehiculoList = new List<cVehiculo>();
        VehiculoList.Add(Furgon);
        VehiculoList.Add(Furgoneta);
        VehiculoList.Add(Camioneta);

        Deposito.AsignarListaVehiculos(VehiculoList);

        Console.WriteLine("~~~ Presione enter para imprimir la lista de vehiculos actualizada ~~~");
        Console.ReadLine();
        Console.Clear();
        Console.Write(Deposito.To_String_Camiones());
        Console.WriteLine("~~~ Presione enter para continuar ~~~");
        Console.ReadLine();
        Console.Clear();

        #endregion Vehiculos 


        #region Carga y reparto
        //for(int i = 0; i < 2; i++)
        //{
            //Console.WriteLine("[[[[[[[[ COMIENZO DE UN NUEVO DIA ]]]]]]]");
        //while(Deposito.CamionesDisponibles())
        //{  
            /*
            if(Deposito.Clientes.Count<10)
            {
                     List<cCliente> ClienteAux = new List<cCliente>();
                    cProducto.cListaProducto ListaPAux = new cProducto.cListaProducto();

                    ClienteAux = Cocimundo.InicializarClientes(15, ref ListaProductos);

                    Deposito.AsignarListaProductos(ListaPAux);
                    Deposito.AsignarListaClientes(ClienteAux);
            }*/
            try{
            
                int n = 0;
               
                Deposito.CargaCamion(ref n); 
                Console.WriteLine("~~~ Cargando el vehiculo : {0} ~~~", Deposito.Vehiculos[n].TipoVehiculo());
                Console.WriteLine("~~~ Presione enter para imprimir la lista de productos a entregar actualizada ~~~");
                Console.ReadLine();
                Console.Clear();
                Console.Write(Deposito.Vehiculos[n].ToString());
                Console.WriteLine("\n~~~ Presione enter para continuar ~~~");
                Console.ReadLine();
                Console.Clear();

               Console.WriteLine("~~~ Ordenando los productos en el camion de acuerdo a la zona y realizando la entrega ~~~");
                List<eZona> Recorrido = new List<eZona>();
                List<cCliente> Cliente = Deposito.Clientes;
                Deposito.Vehiculos[n].RealizarReparto(ref Cliente, Deposito.MapaEntregar, ref Recorrido);   
                Deposito.AsignarListaClientes(Cliente);

                Console.WriteLine("\n~~~ Camino realizado ~~~");
                Console.Write(ToStringRecorrido(Recorrido));
                Console.WriteLine("\n\n~~~ Presione enter para continuar ~~~");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("\n~~~ Datos del vehiculo actualizados ~~~");
                Console.Write(Deposito.Vehiculos[n].ToString());
                Console.WriteLine("\n~~~ Presione enter para continuar ~~~");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("---- FIN DE LA EJECUCION ----");
                Console.WriteLine("\n\n\n~~~ Presione enter para continuar ~~~");
                Console.ReadLine();
                Console.Clear();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
           

        //} 
        /*
         Console.WriteLine(" FIN DEL DIA ");
            Deposito.Productos.ActualizarPrioridades();
            Deposito.ReiniciarVehiculos();*/
        //}
        #endregion Carga y reparto
    }


    public static string ToStringRecorrido(List<eZona> Camino){
        string o;
        if(Camino.Any()){
        o = "\nCAMINO REALIZADO PARA LA ENTREGA: ";

        for(int i = 0; i < Camino.Count-1; i++)
        {
            o+=(Camino[i].ToString() + " - ");
        }
        o+= Camino[Camino.Count-1].ToString();}
        else{o="\nNO SE REALIZARON ENTREGAS";}
        return o;
    }
    
    public static List<cCliente> InicializarClientes(int n, ref cProducto.cListaProducto ListaProductos){
        List<cCliente> Lista = new List<cCliente>();
        for(int i = 0; i < n; i++){
            cCliente nuevo = GenerarCliente();
            eTipoEntrega prioridad = (eTipoEntrega)(rnd.Next(0,3)); // rnd entre 0 y 2
            for(int j = 0; j < nuevo.CantidadProductos; j++){
                cProducto nuevo_producto = GenerarProducto(nuevo.zona, nuevo.codigodeoperacion, prioridad);
                ListaProductos.Agregar(nuevo_producto);
            }
            Lista.Add(nuevo);
        }
        return Lista;
    }

    public static cCliente GenerarCliente(){
        string Nombre_="";
        char L;

	    for (int i = 0; i < 5; i++) // Creo un nombre tipo 'ABCDE'
	    {
		    L = (char)('A' + rnd.Next(26)); // me muevo x posiciones en el abecedario
		    Nombre_ +=L;
	    }

        int Codigo_producto_ = rnd.Next(100000,1000000);// Codigo de 6 digitos
        int Cant_productos = rnd.Next(1,4); // De 1 a 3 productos
        eZona zona = (eZona)rnd.Next(0,25);
        cCliente nuevo = new cCliente(Nombre_, Codigo_producto_, Cant_productos, zona);
        return nuevo;
    }

    static public cProducto GenerarProducto(eZona zona, int codigo_, eTipoEntrega prioridad){
        cProducto nuevo;
        int eleccion = rnd.Next(0,4);

        if(eleccion == 0)
            nuevo = GenerarPequeniosElect(zona,codigo_, prioridad);
        else if(eleccion == 1)
            nuevo = GenerarLineaBlanca(zona, codigo_, prioridad);
        else if(eleccion == 2)
            nuevo = GenerarElectronicos(zona, codigo_, prioridad);
        else
            nuevo = GenerarTelevisor(zona, codigo_, prioridad);
        //cProducto nuevo = new cProducto(Tipo_, ZonaEntrega_,Entrega_,Peso_,dimensiones_,Codigo,Ascensor_);
        return nuevo;
    }

    static public cPequeniosElect GenerarPequeniosElect(eZona zona, int codigo_, eTipoEntrega prioridad){
        eProducto Tipo_;
        float Peso_; 
        sDimensiones dimensiones_; 

        /*Licuadora = 0, Exprimidor, Rallador, Tostadora, Cafetera,	MolinilloDeCafe = 5*/

        int eleccion = rnd.Next(0, 6);

        switch((eProducto)eleccion){
            case eProducto.Licuadora:
                Tipo_ = eProducto.Licuadora;
                Peso_ = rnd.Next(1,3) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(25,30) / (float)100;
                dimensiones_.ancho = rnd.Next(15,21) / (float)100;
                dimensiones_.largo = rnd.Next(20,30) / (float)100;
                break;
            case eProducto.Exprimidor:
                Tipo_ = eProducto.Exprimidor;
                Peso_ = rnd.Next(1,3) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(20,25) / (float)100;
                dimensiones_.ancho = rnd.Next(10,16) / (float)100;
                dimensiones_.largo = rnd.Next(10,16) / (float)100;
                break;
            case eProducto.Rallador:
                Tipo_ = eProducto.Rallador;
                Peso_ = rnd.Next(3,5) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(20,26) / (float)100;
                dimensiones_.ancho = rnd.Next(20,26) / (float)100;
                dimensiones_.largo = rnd.Next(15,20) / (float)100;
                break;
            case eProducto.Tostadora:
                Tipo_ = eProducto.Tostadora;
                Peso_ = rnd.Next(1, 5) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(15,25) / (float)100;
                dimensiones_.ancho = rnd.Next(25,35) / (float)100;
                dimensiones_.largo = rnd.Next(20,30) / (float)100;
                break;
            case eProducto.Cafetera:
                Tipo_ = eProducto.Cafetera;
                Peso_ = rnd.Next(1, 5) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(30,40) / (float)100;
                dimensiones_.ancho = rnd.Next(30,40) / (float)100;
                dimensiones_.largo = rnd.Next(15,25) / (float)100;
                break;
            case eProducto.MolinilloDeCafe:
                Tipo_ = eProducto.MolinilloDeCafe;
                Peso_ = rnd.Next(1,3) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(10,15) / (float)100;
                dimensiones_.ancho = rnd.Next(15,25) / (float)100;
                dimensiones_.largo = rnd.Next(5,10) / (float)100;
                break;
            default:
                Tipo_ = eProducto.Cocina;
                Peso_ = 0;
                dimensiones_.alto = 0;
                dimensiones_.ancho = 0;
                dimensiones_.largo = 0;
                break;
        }

        cPequeniosElect nuevo = new cPequeniosElect(Tipo_, zona,prioridad,Peso_,dimensiones_,codigo_, true);
        return nuevo;
    }

    static public cLineaBlanca GenerarLineaBlanca(eZona zona, int codigo_, eTipoEntrega prioridad){
        eProducto Tipo_;
        float Peso_; 
        sDimensiones dimensiones_; 

        /*Cocina = 6, Calefon, Termotanque, Lavarropas, Secarropas, Heladera, Microondas, Freezer = 13*/

        int eleccion = rnd.Next(6, 14);

        switch((eProducto)eleccion){
            case eProducto.Cocina:
                Tipo_ = eProducto.Cocina;
                Peso_ = rnd.Next(40, 50) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(75,85) / (float)100;
                dimensiones_.ancho = rnd.Next(50, 60) / (float)100;
                dimensiones_.largo = rnd.Next(55, 65) / (float)100;
                break;
            case eProducto.Calefon:
                Tipo_ = eProducto.Calefon;
                Peso_ = rnd.Next(10,15) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(65, 75) / (float)100;
                dimensiones_.ancho = rnd.Next(30, 40) / (float)100;
                dimensiones_.largo = rnd.Next(20,30) / (float)100;
                break;
            case eProducto.Termotanque:
                Tipo_ = eProducto.Termotanque;
                Peso_ = rnd.Next(17,24) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(50,60) / (float)100;
                dimensiones_.ancho = rnd.Next(40,50) / (float)100;
                dimensiones_.largo = rnd.Next(40,50) / (float)100;
                break;
            case eProducto.Lavarropas:
                Tipo_ = eProducto.Lavarropas;
                Peso_ = rnd.Next(55,60) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(75,85) / (float)100;
                dimensiones_.ancho = rnd.Next(55,65) / (float)100;
                dimensiones_.largo = rnd.Next(50,60) / (float)100;
                break;
            case eProducto.Secarropas:
                Tipo_ = eProducto.Secarropas;
                Peso_ = rnd.Next(5,10) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(45,55) / (float)100;
                dimensiones_.ancho = rnd.Next(55,65) / (float)100;
                dimensiones_.largo = rnd.Next(15,20) / (float)100;
                break;
            case eProducto.Heladera:
                Tipo_ = eProducto.Heladera;
                Peso_ = rnd.Next(45,60) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(150,160) / (float)100;
                dimensiones_.ancho = rnd.Next(60,70) / (float)100;
                dimensiones_.largo = rnd.Next(55,65) / (float)100;
                break;
            case eProducto.Microondas:
                Tipo_ = eProducto.Microondas;
                Peso_ = rnd.Next(10,15) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(20,30) / (float)100;
                dimensiones_.ancho = rnd.Next(40,50) / (float)100;
                dimensiones_.largo = rnd.Next(35,40) / (float)100;
                break;
            case eProducto.Freezer:
                Tipo_ = eProducto.Freezer;
                Peso_ = rnd.Next(45,55) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(80,90) / (float)100;
                dimensiones_.ancho = rnd.Next(110, 120) / (float)100;
                dimensiones_.largo = rnd.Next(65,75) / (float)100;
                break;
            default:
                Tipo_ = eProducto.Cocina;
                Peso_ = 0;
                dimensiones_.alto = 0;
                dimensiones_.ancho = 0;
                dimensiones_.largo = 0;
                break;
        }

        cLineaBlanca nuevo = new cLineaBlanca(Tipo_, zona,prioridad,Peso_,dimensiones_,codigo_, true);
        return nuevo;
    }

    static public cElectronicos GenerarElectronicos(eZona zona, int codigo_, eTipoEntrega prioridad){
        eProducto Tipo_;
        float Peso_; 
        sDimensiones dimensiones_; 

        /*Computadoras = 14, Impresoras, PequeniosAccesorios = 16*/

        int eleccion = rnd.Next(14, 17);

        switch((eProducto)eleccion){
            case eProducto.Computadoras:
                Tipo_ = eProducto.Computadoras;
                Peso_ = rnd.Next(1,3) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(2,5) / (float)100;
                dimensiones_.ancho = rnd.Next(30,35) / (float)100;
                dimensiones_.largo = rnd.Next(20,25) / (float)100;
                break;
            case eProducto.Impresoras:
                Tipo_ = eProducto.Impresoras;
                Peso_ = rnd.Next(5,8) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(10,18) / (float)100;
                dimensiones_.ancho = rnd.Next(40,50) / (float)100;
                dimensiones_.largo = rnd.Next(30, 40) / (float)100;
                break;
            case eProducto.PequeniosAccesorios:
                Tipo_ = eProducto.PequeniosAccesorios;
                Peso_ = rnd.Next(1, 5) + (float)rnd.NextDouble();
                dimensiones_.alto = rnd.Next(10, 15) / (float)100;
                dimensiones_.ancho = rnd.Next(10, 15) / (float)100;
                dimensiones_.largo = rnd.Next(10, 15) / (float)100;
                break;
            
            default:
                Tipo_ = eProducto.Computadoras;
                Peso_ = 0;
                dimensiones_.alto = 0;
                dimensiones_.ancho = 0;
                dimensiones_.largo = 0;
                break;
        }

        cElectronicos nuevo = new cElectronicos(Tipo_, zona,prioridad,Peso_,dimensiones_,codigo_, false);
        return nuevo;
    }

    static public cTelevisor GenerarTelevisor(eZona zona, int codigo_, eTipoEntrega prioridad){
        eProducto Tipo_ = eProducto.Televisor;
        float Peso_ = rnd.Next(13,18) + (float)rnd.NextDouble(); 
        sDimensiones dimensiones_; 

        dimensiones_.alto = rnd.Next(40,60) / (float)100;
        dimensiones_.ancho = rnd.Next(60,80) / (float)100;
        dimensiones_.largo = (rnd.Next(15,25)/(float)100);


        cTelevisor nuevo = new cTelevisor(Tipo_, zona,prioridad,Peso_,dimensiones_,codigo_, false);
        return nuevo;
    }

}

