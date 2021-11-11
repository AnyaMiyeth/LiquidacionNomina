using System;
using System.Collections.Generic;
using Dominio;
namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Empleado empleadoPepe = new Empleado {
                Identificacion="2",
                Nombre="Pepe",
                SalarioBase=1000000
            };

            Empleado empleadoMaria = new Empleado
            {
                Identificacion = "1",
                Nombre = "Juan",
                SalarioBase = 800000
            };

            List < Empleado > empleados= new List<Empleado>();
            empleados.Add(empleadoMaria);
            empleados.Add(empleadoPepe);

            LiquidacionNomina liquidacionNomina= new LiquidacionNomina(2021,5,empleados);


            Console.WriteLine($"Liquidación: { liquidacionNomina.Total}");
            foreach (var item in liquidacionNomina.DetalleNominas)
            {
                Console.WriteLine($"{ item.Empleado.Nombre} -{ item.Empleado.SalarioBase}--{ item.AuxilioTransporte}--{ item.Salud}--{ item.Pension}--{ item.TotalDevengado}");
            }
            Console.ReadKey();
        }
    }
}
