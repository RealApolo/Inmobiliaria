using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria
{
    public class Inmueble
    {
        protected string Direccion;
        protected int MT2;        
        protected int Antiguedad;
        protected float PrecioBase;

        public string Dir
        {
            set { Direccion = value; }
            get { return Direccion; }
        }
        public int Metros
        {
            set { MT2 = value; }
            get { return MT2; }
        }

        public int Años
        {
            set { Antiguedad = value; }
            get { return Antiguedad; }
        }

        public float Precio
        {
            set { PrecioBase = value; }
            get { return PrecioBase; }
        }

        public float CalcularDescuentoAntiguedad()
        {
            float Descuento = 0;
            if (Antiguedad<= 15 && Antiguedad !=0)
            {
                 Descuento = -1;
                return Descuento;
            }
            if (Antiguedad>15)
            {
                Descuento = -2;
                return Descuento;
            }
            
            return Descuento;

        }

    }

    public class Piso : Inmueble
    {
        protected int NroPiso;


        public Piso()
        {
            Console.WriteLine("Ingrese la direccion del Inmueble");
            this.Dir = Console.ReadLine();

            Console.WriteLine("Ingrese tamaño (en MT2)");
            this.Metros = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese numero del Piso");
            this.ALTURA = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Antiguedad (0 si es nuevo)");
            this.Años = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Precio Base");
            this.Precio = float.Parse(Console.ReadLine());

        }

        public float CalcularValor()
        {

            float valor = this.Precio;
            valor = valor + (valor * CalcularDescuentoAntiguedad()/100f) + (valor * CalcularPorcentajePiso()/100);
            return valor;
        }

        float CalcularPorcentajePiso()
        {
            float Valor = 0;
            if (NroPiso >= 3)
            {
                Valor = 3;
                return Valor;
            }

            return Valor;
        }
        public int ALTURA
        {
            set { NroPiso = value; }
            get { return NroPiso; }
        }
    }

    public class Local : Inmueble
    {
        protected int CantVentanas;

        public Local()
        {
            Console.WriteLine("Ingrese la direccion del Inmueble");
            this.Dir = Console.ReadLine();

            Console.WriteLine("Ingrese tamaño (en MT2)");
            this.Metros = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Cantidad de ventanas");
            this.Ventanas = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Antiguedad (0 si es nuevo)");
            this.Años = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Precio Base");
            this.Precio = float.Parse(Console.ReadLine());
        }

        public float CalcularValor()
        {

            float valor = this.Precio;
            valor = valor + (valor * CalcularDescuentoAntiguedad() / 100f) + (valor * CalcularPorcentajeVentanas() / 100)
                + (valor * CalPorcentajeMetros()/ 100);
            return valor;
        }


        float CalcularPorcentajeVentanas()
        {
            float valor = -2;
            if (this.Ventanas > 4)
            {
                valor = 2;
            }
            return valor;
        }

        float CalPorcentajeMetros()
        {
            float valor = 0;
            if (this.Metros > 50)
            {
                valor = 1;
            }
            return valor;
        }
        public int Ventanas
        {
            set { CantVentanas = value; }
            get { return CantVentanas; }
        }

    }


    class Program
    {
       
        static void Main(string[] args)
        {
            string TipoInm ;
            Inmueble INMB = new Inmueble();
            
            
            Console.WriteLine("Bienvenido a su calculadora de precios inmobiliarios");
            Console.WriteLine("Ingrese si su inmueble es un PISO o LOCAL");
            Console.WriteLine("1 = Piso");
            Console.WriteLine("2 = Local");
                       
            ChequearValorTipoInmb(Int32.Parse( Console.ReadLine()));

            

            if (TipoInm == "PISO")
            {
                Piso PisoINMB = new Piso();
                Console.WriteLine(PisoINMB.CalcularValor());
                
            }
            if (TipoInm == "LOCAL")
            {
                Local LocalINMB = new Local();
                Console.WriteLine(LocalINMB.CalcularValor());
            }

            


            Console.ReadKey();


            void ChequearValorTipoInmb(int value)
            {
                
                switch (value)
                {
                    case 1:                        
                        TipoInm = "PISO";
                        break;
                    case 2:                       
                        TipoInm = "LOCAL";
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("ERROR");
                        Console.WriteLine("Ingrese si su inmueble es un PISO o LOCAL");
                        Console.WriteLine("1 = Piso");
                        Console.WriteLine("2 = Local");
                        ChequearValorTipoInmb(Int32.Parse(Console.ReadLine()));
                        break;

                }
                
            }
        }

        
    }

    
}
