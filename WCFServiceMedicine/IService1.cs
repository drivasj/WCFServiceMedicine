using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFServiceMedicine.Class;

namespace WCFServiceMedicine
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // Medicine list
        [OperationContract]
        List<MedicineCLS> listMedicine();

        // Forma farmaceutica list
        List<FormaFarmaceuticaCLS> listFormaFarmaceitica();

        // Recuperar Medicamento
        MedicineCLS GetMedicine(int iidMedicne);

        // Add and Edit Medicine
        int GetMedicine(MedicineCLS oMedicineCLS);

        //Delete medicine
        int deleteMedicine(int iidMedicne);


    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}
