using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{


    /*Primero, necesitaremos nuestra interfaz de Mediador ,
     * que define un método por el cual las barras de bocadillos
     * pueden comunicarse entre sí:
     */


    interface Mediator
    {
        void SendMessage(string message, ConcessionStand concessionStand);
    }

    /*Finalmente, podemos implementar la clase ConcreteMediator ,
     que mantendrá una referencia a cada colega y 
         gestionará la comunicación entre ellos.
         */


    class ConcessionsMediator : Mediator
    {
        private NorthConcessionStand _northConcessions;
        private SouthConcessionStand _southConcessions;

        public NorthConcessionStand NorthConcessions
        {
            set { _northConcessions = value; }
        }

        public SouthConcessionStand SouthConcessions
        {
            set { _southConcessions = value; }
        }

        public void SendMessage(string message, ConcessionStand colleague)
        {
            if (colleague == _northConcessions)
            {
                _southConcessions.Notify(message);
            }
            else
            {
                _northConcessions.Notify(message);
            }
        }
    }

    /*También necesitamos una clase abstracta
       * para representar a los colegas que
       * hablarán entre ellos:
       */
    abstract class ConcessionStand
    {
        protected Mediator mediator;

        public ConcessionStand(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    /*Ahora implementemos los diferentes colegas.En este caso, 
            simularemos que nuestra sala de cine tiene dos bares: 
            uno en la parte norte del teatro y otro en la parte sur.   
            */
    class NorthConcessionStand : ConcessionStand
    {
        // Constructor
        public NorthConcessionStand(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            Console.WriteLine("North Concession Stand sends message: " + message);
            mediator.SendMessage(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("North Concession Stand gets message: " + message);
        }
    }

  
    class SouthConcessionStand : ConcessionStand
    {
        public SouthConcessionStand(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            Console.WriteLine("South Concession Stand sends message: " + message);
            mediator.SendMessage(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("South Concession Stand gets message: " + message);
        }
    }
}