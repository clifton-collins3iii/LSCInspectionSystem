using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSCservice.ServiceData
{
    public class SourceContactObject
    {
        public SourceContactObject() { }

        public int PK_SourceContact_Id { get; set; }
        public int FK_Source_Id { get; set; }
        public int FK_Contact_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string SourceName { get; set; }
        public string SourceDescription { get; set; }
        public string Contacts_Name { get; set; }
        public string Contacts_Description { get;set; }

    }

    public class SourceContactObjectRow
    {

        public int PK_SourceContact_Id { get; set; }
        public int FK_Source_Id { get; set; }
        public int FK_Contact_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string SourceName { get; set; }
        public string SourceDescription { get; set; }
        public string Contacts_Name { get; set; }
        public string Contacts_Description { get; set; }

    }
}
