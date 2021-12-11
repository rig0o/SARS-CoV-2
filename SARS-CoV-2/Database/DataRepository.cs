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

        public List<DatasetDto> GetDataRealista()
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
        public List<DatasetDto> GetDataPesimista()
        {
            IEnumerable<DatasetDto> lst = from d in _dbcontext.Datasets
                                          select new DatasetDto
                                          {
                                              Fecha = d.Fecha,
                                              CnuevoTotales = d.CnuevoTotales,
                                              CconfirmadosRecuperados = d.CconfirmadosRecuperados,
                                              CactivosConfirmados = 1.9,
                                              CactivosProbables = d.CactivosProbables,
                                              CsospechaReinfeccion = d.CsospechaReinfeccion,
                                              PcrDiarios = 1.7,
                                              MediaMovil = 2,
                                              Refectivo = 1.6, //1 o 1.6
                                              PositividadPcr = 2.9,
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
        public List<DatasetDto> GetDataOptimista()
        {
            IEnumerable<DatasetDto> lst = from d in _dbcontext.Datasets
                                          select new DatasetDto
                                          {
                                              Fecha = d.Fecha,
                                              CnuevoTotales = d.CnuevoTotales,
                                              CconfirmadosRecuperados = d.CconfirmadosRecuperados,
                                              CactivosConfirmados = 0,
                                              CactivosProbables = d.CactivosProbables,
                                              CsospechaReinfeccion = d.CsospechaReinfeccion,
                                              PcrDiarios = 0,
                                              MediaMovil = 0,
                                              Refectivo = 0,
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
        public List<DatasetDto> GetDataModificado(double Lsc, double Ovll, double Illap, double Salamc, double Mp, long EstadoE, long Pm, long Pv, long Alpha, long Gamma, long Delta)
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
                                              PppConurbacioLaSerenaCoquimbo = Lsc,
                                              PppOvalle = Ovll,
                                              PppIllapel = Illap,
                                              PppSalamanca = Salamc,
                                              PppMontePatria = Mp,
                                              PrimeraDosis = d.PrimeraDosis,
                                              SegundaDosis = d.SegundaDosis,
                                              UnicaDosis = d.UnicaDosis,
                                              RefuerzoDosis = d.RefuerzoDosis,
                                              CconfirmadosAntigeno = d.CconfirmadosAntigeno,
                                              PermisoVacaciones = Pv,
                                              PaseMovilidad = Pm,
                                              EstadoExcepcion = EstadoE,
                                              Alpha = Alpha,
                                              Gamma = Gamma,
                                              Delta = Delta

                                          };
            lst = lst.TakeLast(10);
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
        public List<DateTimePoint> GetDataGraph()
        {
            var lst  = from d in _dbcontext.Datasets
                                           select new DateTimePoint
                                           {
                                               DateTime = d.Fecha,
                                               Value = d.CnuevoTotales
                                           };
            var norma = lst.ToList();

            foreach (var item in norma)
            {
                item.Value = DesNorm((double)item.Value);
            }

            return norma;
        }

        public List<DateTimePoint> GetDataGraphPesimista(Dictionary<int, double[,]> predict)
        {
            List<DateTimePoint> lst = new List<DateTimePoint>();
            var lis = from d in _dbcontext.Datasets
                      select new GraficoDto
                      {
                          Fecha = d.Fecha,
                          CnuevoTotales = d.CnuevoTotales

                      };
            var fecha = lis.Last();

            DateTime lastDay = fecha.Fecha;
            lastDay = lastDay.AddDays(1);

            for (int i = 0; i < predict.Count; i++)
            {
                lst.Add(new DateTimePoint
                {
                    DateTime = lastDay,
                    Value = predict[i][0,0]
                }) ;
                lastDay = lastDay.AddDays(1);
            }

            foreach (var item in lst)
            {
                item.Value = DesNorm((double)item.Value);
            }

            return lst;
        }
        public List<DateTimePoint> GetDataGraphOptimista()
        {
            var lst = from d in _dbcontext.Datasets
                      select new DateTimePoint
                      {
                          DateTime = d.Fecha,
                          Value = d.CnuevoTotales

                      };
            var norma = lst.ToList();

            foreach (var item in norma)
            {
                item.Value = DesNorm((double)item.Value);
            }

            return norma;
        }
        public List<DateTimePoint> GetDataGraphRealista(Dictionary<int, double[,]> predict)
        {
            List<DateTimePoint> lst = new List<DateTimePoint>();
            var listafechas = GetDataRealista();

            DateTime lastDay = listafechas.Last<DatasetDto>().Fecha;
            lastDay = lastDay.AddDays(1);

            for (int i = 0; i < predict.Count; i++)
            {
                lst.Add(new DateTimePoint
                {
                    DateTime = lastDay,
                    Value = predict[i][0, 0]
                });
                lastDay = lastDay.AddDays(1);
            }

            foreach (var item in lst)
            {
                item.Value = DesNorm((double)item.Value);
            }

            return lst;
        }

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
