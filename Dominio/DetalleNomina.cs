using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class DetalleNomina
    {
        public LiquidacionNomina LiquidacionNomina { get; private set; }
        public string Id { get; private set; }
        public Empleado Empleado { get; private set; }
        public int Mes { get; private set; }
        public int Anio { get; set; }
        public decimal AuxilioTransporte { get; private set; }
        public decimal Pension { get; private set; }
        public decimal Salud { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalDevengado { get; set; }
        const decimal SMLV = 900000;
        const decimal VALORAUXILIOTRANSPORTE = 90000;
        public DetalleNomina(Empleado empleado, LiquidacionNomina liquidacionNomina, int mes, int anio)
        {
            Empleado = empleado;
            Mes = mes;
            Anio = anio;
            LiquidacionNomina = liquidacionNomina;
            calcularSalarioIntegral();
          
        }
        private void calcularAxiliTransporte() 
        {
            AuxilioTransporte= Empleado.SalarioBase < 2*SMLV ? VALORAUXILIOTRANSPORTE : 0;
        }

        private void calcularSalud()
        {
            Salud = Empleado.SalarioBase *0.04m;
        }

        private void calcularPension()
        {
            Pension= Empleado.SalarioBase * 0.04m;
        }

        private void calcularSalarioIntegral()
        {
            calcularPension();
            calcularSalud();
            calcularAxiliTransporte();
            TotalDevengado = Empleado.SalarioBase - Salud - Pension + AuxilioTransporte;
        }
        

    }
}
