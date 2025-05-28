using System;

namespace LSCservice.ServiceData
{
    public class MySurveyObject
    {
        public MySurveyObject() { }

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

    public class MySurveyObjectRow
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

    public class MySurveyOptionsObject
    {
        public int Value { get; set; }
        public string DisplayText { get; set; }
    }
}
