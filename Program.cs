using System;
using System.Collections.Generic;

namespace banco
{
    class Tarjeta
    {
        // todo: metodo para sacar e ingresar dinero con cajero
        public Cliente Lambda = new Cliente();
        
        public void AlterarSaldo(double saldoAAlterar){
            Lambda.saldo = Lambda.saldo + saldoAAlterar;
            System.Console.WriteLine("Tu saldo actual es: "+ Lambda.saldo);
            System.Console.WriteLine("");
        }
    }
    class Cajero
    {
        // Todo: metodo para sacar dinero con tarjeta
            public Tarjeta t1 = new Tarjeta();
        bool tarjetaIntroducida = false;
        public Tarjeta IngrasarTarjeta(){
            tarjetaIntroducida = true;
            System.Console.WriteLine("Numero de cuenta: "+t1.Lambda.numeroCuenta);
            System.Console.WriteLine("Nombre de cuenta: "+t1.Lambda.nombreDeUsuario);
            System.Console.WriteLine("Cantidad de saldo en la cuenta: "+t1.Lambda.saldo);
            System.Console.WriteLine("");
            return(t1);
        }
        public Transaccion transa1 = new Transaccion();
        public Transaccion Sacardinero(double cantidadARetirar){
            if (tarjetaIntroducida == true)
            {
                transa1.RealisarTransaccion(cantidadARetirar);
                System.Console.WriteLine(transa1.RealisarTransaccion(cantidadARetirar));
                System.Console.WriteLine("");
                t1.AlterarSaldo(cantidadARetirar);
            }else{System.Console.WriteLine("No hay tarjeta introducida");
            System.Console.WriteLine("");}
            return(transa1);
            
        }
        public void SacarTarjeta(){
            if (tarjetaIntroducida == true)
            {
                tarjetaIntroducida = false;
                System.Console.WriteLine("Tarjeta retirada :)");
                System.Console.WriteLine("");
            }else{System.Console.WriteLine("No hay tarjeta introducida");
            System.Console.WriteLine("");}
        }
    }
    class Cliente
    {
        //  Todo: contener numero de cuenta, info general del cliente y saldo
        public string numeroCuenta = "1";
        public string nombreDeUsuario = "Lambda";

        public double saldo; // el cliente posee el saldo al que se le altera la cantidad
        public double CsmbiarSaldo(double saldoAA){
            saldo = saldoAA;
            return(saldo);
        }
    }
    class Sucursal
    {
        // todo: info de la sucursal
        public string sucursal = "Banco chido";
        public Cajero Caj1 = new Cajero();
    }
    class Transaccion
    {
        //  todo: contener info de todas las transacciones (stak)
        Stack<string> transacciones = new Stack<string>();
        public string RealisarTransaccion(double saldoTransa){
            transacciones.Push("Tusaldo fue alterado por: "+ saldoTransa);
            // return (transacciones.Peek); como le ago para que me regrese el tope del stack?
            return ("Tusaldo fue alterado por: "+ saldoTransa);
        }
        public void muestralas(){
            string joinedString = String.Join(",", transacciones);

            Console.WriteLine(joinedString);    
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Transaccion t1 = new Transaccion();
            // System.Console.WriteLine( t1.RealisarTransaccion());


            // ToDo: que muestre todas las transacciones

            Sucursal s1 = new Sucursal();
            System.Console.WriteLine("Bienbenido a "+s1.sucursal);
            System.Console.WriteLine("");

            System.Console.WriteLine("0: insertar tarjeta");
            System.Console.WriteLine("1: meter o sacar dinero");
            System.Console.WriteLine("2: retirar tarjeta");
            System.Console.WriteLine("3: revisar transacciones");
            System.Console.WriteLine("4: salir");

            bool dentro = true;
            while (dentro == true)
            {
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 0:
                        s1.Caj1.IngrasarTarjeta();
                    break;
                    case 1:
                        s1.Caj1.Sacardinero(Convert.ToDouble(Console.ReadLine()));
                    break;
                    case 2 :
                        s1.Caj1.SacarTarjeta();
                    break;
                    case 3:
                        s1.Caj1.transa1.muestralas();
                    break;
                    case 9:
                    break;
                    default:
                        dentro = false;
                    break;
                }
                    menu = 9;
            }

            
        }
    }
}
