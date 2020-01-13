using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /*En nuestro Main(), podemos usar nuestro Mediador
             * recién escrito para simular una conversación de chat
             * entre las dos cafeterías. 
             * Suponga que una de las barras de bocadillos se ha quedado 
             * sin palomitas de maíz y necesita saber si la otra tiene 
             * más que no están usando
             * 
             */
            ConcessionsMediator mediator = new ConcessionsMediator();

            NorthConcessionStand leftKitchen = new NorthConcessionStand(mediator);
            SouthConcessionStand rightKitchen = new SouthConcessionStand(mediator);

            mediator.NorthConcessions = leftKitchen;
            mediator.SouthConcessions = rightKitchen;

            leftKitchen.Send("¿Puedes envíar palomitas de maíz");
            rightKitchen.Send("Claro, Kenny está en camino..");

            rightKitchen.Send("¿Tienes perros calientes extra ? Hemos tenido prisa por ellos por aquí.");
            leftKitchen.Send("Solo un par, enviaremos a Kenny con ellos.");

          
            Console.ReadKey();
        }
    }
}