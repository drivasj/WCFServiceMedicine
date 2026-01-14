using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServiceMedicine.Class
{
    [DataContract]
    public class MedicineCLS
    {
        [DataMember(Order = 0)]
        public int iidmedicamento { get; set; }

        [DataMember(Order = 1)]
        public string nombre { get; set; }

        [DataMember(Order = 2)]
        public string concentracion { get; set; }

        [DataMember(Order = 3)]
        public int iidformafarmaceutica { get; set; }

        [DataMember(Order = 4)]
        public string nombreFormaFarmaceutica { get; set; }

        [DataMember(Order = 5)]
        public decimal precio { get; set; }

        [DataMember(Order = 6)]
        public int stock { get; set; }

        [DataMember(Order = 7)]
        public string presentacion { get; set; }

        [DataMember(Order = 8)]
        public int active { get; set; }
    }
}