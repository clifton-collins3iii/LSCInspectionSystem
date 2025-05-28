using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSCservice.ServiceData
{
    public class BuildingObject
    {
        public BuildingObject() { }

        public int PK_Building_Id { get; set; }
        public int FK_Campus_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string Name_Short { get; set; }
        public string Name_Long { get; set; }
        public string Description { get; set; }
        public string AddressStreet { get; set; }
        public string AddressUnit { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }


    }

    public class BuildingObjectRow
    {
        public int PK_Building_Id { get; set; }
        public int FK_Campus_Id {  get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string Name_Short { get; set; }
        public string Name_Long { get; set; }
        public string Description { get; set; }
        public string AddressStreet { get; set; }
        public string AddressUnit { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
    }

    public class BuildingOptionsObject
    {
        public int Value { get; set; }
        public string DisplayText { get; set; }
    }
}
