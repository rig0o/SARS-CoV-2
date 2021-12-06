using SARS_CoV_2.Database.Dto;
using SARS_CoV_2.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARS_CoV_2.Database
{
    public class DataRepository
    {
        private readonly datasetContext _dbcontext;

        public DataRepository()
        {
            _dbcontext = new datasetContext();
        }
        public List<DatasetDto> GetDataTrain()
        {
            IEnumerable<DatasetDto> lst = from d in _dbcontext.Datasets
                                          select new DatasetDto {
                                           Fecha = d.Fecha,
                                           CnuevoTotales = d.CnuevoTotales,
                                           PcrDiarios = d.PcrDiarios,
                                           MediaMovil = d.MediaMovil,
                                           Refectivo = d.Refectivo,
                                           PositividadPcr = d.PositividadPcr,
                                           TasaTest = d.TasaTest,
                                           PppConurbacioLaSerenaCoquimbo =d.PppConurbacioLaSerenaCoquimbo,
                                           PppOvalle = d.PppOvalle,
                                           PppIllapel =d.PppIllapel,
                                           PppSalamanca = d.PppSalamanca,
                                           PppMontePatria = d.PppMontePatria,
                                           PrimeraDosis = d.PrimeraDosis,
                                           SegundaDosis = d.SegundaDosis,
                                           UnicaDosis = d.UnicaDosis,
                                           RefuerzoDosis =d.RefuerzoDosis,
                                           CconfirmadosAntigeno = d.CconfirmadosAntigeno,
                                           PermisoVacaciones = d.PermisoVacaciones,
                                           PaseMovilidad = d.PaseMovilidad,
                                           EstadoExcepcion =d.EstadoExcepcion,
                                           Alpha = d.Alpha,
                                           Gamma = d.Gamma,
                                           Delta = d.Delta

                                         };
            return lst.ToList();
        }

        public IEnumerable<GraficoDto> GetDataGraph()
        {
            return from d in _dbcontext.Datasets
                   select new GraficoDto
                   {
                       Fecha = d.Fecha,
                       CnuevoTotales = d.CnuevoTotales

                   };
        }
    }
}
