using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLservice.ServiceData
{
    public class CampusObject
    {
        public CampusObject() { }

        public int PK_Campus_Id { get; set; }
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

    public class CampusObjectRow
    {
        public int PK_Campus_Id { get; set; }
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

    public class CampusOptionsObject
    {
        public int Value { get; set; }
        public string DisplayText { get; set; }
    }
}
