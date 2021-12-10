using LiveChartsCore.Defaults;
using SARS_CoV_2.Database.Dto;
using SARS_CoV_2.Database.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public List<DatasetDto> GetDataForward()
        {
            IEnumerable<DatasetDto> lst = from d in _dbcontext.Datasets
                                          select new DatasetDto
                                          {
                                              Fecha = d.Fecha,
                                              CnuevoTotales = d.CnuevoTotales,
                                              CconfirmadosRecuperados = d.CconfirmadosRecuperados,
                                              CactivosConfirmados = d.CactivosConfirmados,
                                              CactivosProbables = d.CactivosProbables,
                                              CsospechaReinfeccion = d.CsospechaReinfeccion,
                                              PcrDiarios = d.PcrDiarios,
                                              MediaMovil = d.MediaMovil,
                                              Refectivo = d.Refectivo,
                                              PositividadPcr = d.PositividadPcr,
                                              TasaTest = d.TasaTest,
                                              PppConurbacioLaSerenaCoquimbo = d.PppConurbacioLaSerenaCoquimbo,
                                              PppOvalle = d.PppOvalle,
                                              PppIllapel = d.PppIllapel,
                                              PppSalamanca = d.PppSalamanca,
                                              PppMontePatria = d.PppMontePatria,
                                              PrimeraDosis = d.PrimeraDosis,
                                              SegundaDosis = d.SegundaDosis,
                                              UnicaDosis = d.UnicaDosis,
                                              RefuerzoDosis = d.RefuerzoDosis,
                                              CconfirmadosAntigeno = d.CconfirmadosAntigeno,
                                              PermisoVacaciones = d.PermisoVacaciones,
                                              PaseMovilidad = d.PaseMovilidad,
                                              EstadoExcepcion = d.EstadoExcepcion,
                                              Alpha = d.Alpha,
                                              Gamma = d.Gamma,
                                              Delta = d.Delta

                                          };
            lst = lst.TakeLast(10);
            //lst = lst.Take(10);
            return lst.ToList();
        }
        public List<DatasetDto> GetDataTrain()
        {
            IEnumerable<DatasetDto> lst = from d in _dbcontext.Datasets.Take(462)
                                          select new DatasetDto
                                          {
                                              Fecha = d.Fecha,
                                              CnuevoTotales = d.CnuevoTotales,
                                              CconfirmadosRecuperados = d.CconfirmadosRecuperados,
                                              CactivosConfirmados = d.CactivosConfirmados,
                                              CactivosProbables = d.CactivosProbables,
                                              CsospechaReinfeccion = d.CsospechaReinfeccion,
                                              PcrDiarios = d.PcrDiarios,
                                              MediaMovil = d.MediaMovil,
                                              Refectivo = d.Refectivo,
                                              PositividadPcr = d.PositividadPcr,
                                              TasaTest = d.TasaTest,
                                              PppConurbacioLaSerenaCoquimbo = d.PppConurbacioLaSerenaCoquimbo,
                                              PppOvalle = d.PppOvalle,
                                              PppIllapel = d.PppIllapel,
                                              PppSalamanca = d.PppSalamanca,
                                              PppMontePatria = d.PppMontePatria,
                                              PrimeraDosis = d.PrimeraDosis,
                                              SegundaDosis = d.SegundaDosis,
                                              UnicaDosis = d.UnicaDosis,
                                              RefuerzoDosis = d.RefuerzoDosis,
                                              CconfirmadosAntigeno = d.CconfirmadosAntigeno,
                                              PermisoVacaciones = d.PermisoVacaciones,
                                              PaseMovilidad = d.PaseMovilidad,
                                              EstadoExcepcion = d.EstadoExcepcion,
                                              Alpha = d.Alpha,
                                              Gamma = d.Gamma,
                                              Delta = d.Delta
                                          };
            return lst.ToList();
        }
        public List<GraficoDto> GetDataTarget()
        {
            var lis = from d in _dbcontext.Datasets
                   select new GraficoDto
                   {
                       Fecha = d.Fecha,
                       CnuevoTotales = d.CnuevoTotales

                   };
            return lis.ToList();
        }

        //public ObservableCollection<DateTimePoint> GetDataGraph()
        //{
        //    ObservableCollection < DateTimePoint > x = from d in _dbcontext.Datasets
        //              select new DateTimePoint
        //              {
        //                  DateTime = d.Fecha,
        //                  Value = d.CnuevoTotales

        //              };
        //    return lis;
        //}

        public static double[,] DesNorm(double[,] x)
        {
            double[,] aux = new double[x.GetLength(0),x.GetLength(1)];

            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int  j = 0;  j < x.GetLength(1);  j++)
                {
                    aux[i,j] = DesNorm(x[i,j]);  //return value * (max - min) + min;
                }
            }
            return aux;
        }
        public static double DesNorm(double x)
        {

            return Math.Round(x * (385 - 4) + 4);  //return value * (max - min) + min;

        }
    }
}
