namespace tp_final;


/*TODO 
--> Revisar inicializacion de listas en clases / constructores
--> No olvidar checkeo de si las listas estan vacias
    bool chk = !lista.Any();
--> Formatear ToStrings
--> Sobrecargas para imprimir
--> Sobregargas para agregar [DONE para la lista de productos]
-->Eliminar clase cZona y reemplazarla por el enum 
-->En la funcion entregar hay q calcular lo consumido
-->En forms le damos la opcion de iniciar otro dia, si lo elige que actualice las prioridades y reiniciar los caminos que pueden hacer los camiones 
-->Si no podemos hacer una funcion tic y modificar cuanto tiempo pasa con cada ejecucion
Trini:
Lara:
ordenar por prioridad [DONE]
geters [Voy viendo los necesarios, no vamos a hacer por demas]
obtener volumenes [DONE]
entregar [DONE]
obtener pesos [DONE]
tiene ascensor [DONE]
 
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
 
 PARA MAIN:
- Funciones de inicializacion de producto (random)
- Funciones de inicializacion de clientes random ?
--> Pasar la matriz con las distancias 
^^ Para estas las tengo hechas de musimundo; los clientes son letras al azar nomas, ver de como adaptarlas a c#
 */


static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        Application.Run(new Form1());
    }    
}