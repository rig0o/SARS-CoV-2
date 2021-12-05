using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARS_CoV_2.Database.Models
{
    class Dataset
    {
        public DateTime Fecha { get; set; }
        public double? CnuevoTotales { get; set; }
        public double? CnuevoSinNotificar { get; set; }
        public double? CconfirmadosRecuperados { get; set; }
        public double? CactivosConfirmados { get; set; }
        public double? CactivosProbables { get; set; }
        public double? CsospechaReinfeccion { get; set; }
        public double? PcrDiarios { get; set; }
        public double? CnuevosConSintomas { get; set; }
        public double? CnuevosSinSintomas { get; set; }
        public double? MediaMovil { get; set; }
        public double? Refectivo { get; set; }
        public double? PositividadPcr { get; set; }
        public double? TasaTest { get; set; }
        public double? PppConurbacioLaSerenaCoquimbo { get; set; }
        public double? PppOvalle { get; set; }
        public double? PppIllapel { get; set; }
        public double? PppSalamanca { get; set; }
        public double? PppMontePatria { get; set; }
        public double? PrimeraDosis { get; set; }
        public double? SegundaDosis { get; set; }
        public double? UnicaDosis { get; set; }
        public double? RefuerzoDosis { get; set; }
        public double? CconfirmadosAntigeno { get; set; }
        public long? PermisoVacaciones { get; set; }
        public long? PaseMovilidad { get; set; }
        public long? EstadoExcepcion { get; set; }
        public long? Alpha { get; set; }
        public long? Gamma { get; set; }
        public long? Delta { get; set; }
    }
}
