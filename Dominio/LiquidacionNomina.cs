using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class LiquidacionNomina
    {
        public string Id { get; private set; }
        public DateTime FechaLiquidacion { get; set; }
        public int Mes { get; private set; }
        public int Anio { get; private set; }
        public decimal TotalAuxilioTransporte { get; private set; }
        public decimal TotalPension { get; private set; }
        public decimal TotalSalud { get; private set; }
        public decimal Total { get; private set; }

        public List<DetalleNomina> DetalleNominas { get; private set; }
        public LiquidacionNomina(int mes, int anio, List<Empleado> empleados)
        {
            Mes = mes;
            Anio = anio;
            CalcularNomina(empleados);
            CalcularTotalAuxilioTransporte();
            CalcularTotalSalud();
            CalcularTotalPension();
            CalcularTotalSalarioIntegral();

        }
        private void CalcularNomina(List<Empleado> empleados)
        {
            DetalleNominas = empleados.Select(p => new DetalleNomina(p, this, Mes, Anio)).ToList();

            foreach (var item in empleados)
            {
                DetalleNomina detalle = new DetalleNomina(item, this, Mes, Anio);
                DetalleNominas.Add(detalle);
            }
         
        }
        private void CalcularTotalAuxilioTransporte()
        {
            TotalAuxilioTransporte = DetalleNominas.Sum(d => d.AuxilioTransporte);
        }
        private void CalcularTotalSalud()
        {
            TotalSalud = DetalleNominas.Sum(d => d.Salud);
        }
        public void CalcularTotalPension()
        {
            TotalPension = DetalleNominas.Sum(d => d.Pension);
        }
        private void CalcularTotalSalarioIntegral()
        {
            Total = DetalleNominas.Sum(d => d.TotalDevengado);
        }

    }
}
