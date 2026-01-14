using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFServiceMedicine.Class;
using WCFServiceMedicine.Models;

namespace WCFServiceMedicine
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        int IService1.deleteMedicine(int iidMedicne)
        {
            int rpta = 0;

            try
            {
                using (var db = new MedicineEntities())
                {
                    Medicamento oMEDICAMENTO = db.Medicamento.Where(P => P.IIDMEDICAMENTO == iidMedicne).First();
                    oMEDICAMENTO.BHABILITADO = 0;
                    db.SaveChanges();
                    rpta = 1;
                }
            }
            catch (Exception ex)
            {
                rpta = 0;
            }
            return rpta;
        }

        MedicineCLS IService1.GetMedicine(int iidMedicne)
        {
            MedicineCLS oMedicamentoCLS = new MedicineCLS ();
            try
            {
                using (var db = new MedicineEntities())
                {
                    Medicamento oMedicamento = db.Medicamento.Where(x => x.IIDMEDICAMENTO == iidMedicne).First();

                    oMedicamentoCLS.iidmedicamento = oMedicamento.IIDMEDICAMENTO;
                    oMedicamentoCLS.iidformafarmaceutica = (int)oMedicamento.IIDFORMAFARMACEUTICA;

                    oMedicamentoCLS.nombre = oMedicamento.NOMBRE;
                    oMedicamentoCLS.precio = (decimal)oMedicamento.PRECIO;
                    oMedicamentoCLS.stock = (int)oMedicamento.STOCK;
                    oMedicamentoCLS.concentracion = oMedicamento.CONCENTRACION;
                    oMedicamentoCLS.presentacion = oMedicamento.PRESENTACION;

                }
            }
            catch (Exception ex)
            {
                 oMedicamentoCLS = null;
            }

            return oMedicamentoCLS;
        }

        int IService1.GetMedicine(MedicineCLS oMedicineCLS)
        {
            throw new NotImplementedException();
        }

        List<FormaFarmaceuticaCLS> IService1.listFormaFarmaceitica()
        {
            List<FormaFarmaceuticaCLS> listaFormaFarmaceutica = new List<FormaFarmaceuticaCLS>();
            try
            {
                using (var db=new MedicineEntities())
                {
                    listaFormaFarmaceutica = db.FormaFarmaceutica.Select(p => new FormaFarmaceuticaCLS
                    {
                        iidformafarmaceutica = p.IIDFORMAFARMACEUTICA,
                        nombreFormaFarmaceutica = p.NOMBRE
                    }).ToList();
                }
            }
            catch (Exception)
            {
                listaFormaFarmaceutica = null;
            }

            return listaFormaFarmaceutica;
        }

        List<MedicineCLS> IService1.listMedicine()
        {
            List<MedicineCLS> listaMedicamento = new List<MedicineCLS>();
            try
            {

                using (var db = new MedicineEntities())
                {
                    listaMedicamento = (from medicamento in db.Medicamento
                                        join formaFarmaceutica in db.FormaFarmaceutica
                                        on medicamento.IIDFORMAFARMACEUTICA equals formaFarmaceutica.IIDFORMAFARMACEUTICA
                                        select new MedicineCLS
                                        {
                                            iidmedicamento = medicamento.IIDMEDICAMENTO,
                                            nombre = medicamento.NOMBRE,
                                            precio = (decimal)medicamento.PRECIO,
                                            nombreFormaFarmaceutica = formaFarmaceutica.NOMBRE,
                                            concentracion = medicamento.PRESENTACION,
                                            stock= (int)medicamento.STOCK
                                        }).ToList();
                                      
                }
            }
            catch (Exception)
            {
                listaMedicamento = null;
            }

            return listaMedicamento;
        }
    }
}
