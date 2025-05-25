using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLservice.ServiceData
{
    public class SourceObject
    {
        public SourceObject() { }

        public int PK_Source_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string Source_Name { get; set; }
        public string SourceDescription { get; set; }
        public string AddressStreet { get; set; }
        public string AddressUnit { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }

        public string OfficePhoneNumber { get; set; }
        public string OfficeEmailAddress { get; set; }

    }

    public class SourceObjectRow
    {
        public int PK_Source_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string Source_Name { get; set; }
        public string SourceDescription { get; set; }
        public string AddressStreet { get; set; }
        public string AddressUnit { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string OfficeEmailAddress { get; set; }

    }

    public class SourceOptionsObject
    {
        public int Value { get; set; }
        public string DisplayText { get; set; }
    }
}
