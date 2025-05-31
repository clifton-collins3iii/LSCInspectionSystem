using System;

namespace LSCservice.ServiceData
{
    public class MySurveyObject
    {
        public MySurveyObject() { }

        public int PK_InspectionSurvey_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime ReviewedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string TemplateName { get; set; }
        public string CampusName { get; set; }
        public string UserName { get; set; }
    }

    public class MySurveyObjectRow
    {
        public int PK_InspectionSurvey_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime ReviewedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string TemplateName { get; set; }
        public string CampusName { get; set; }
        public string UserName { get; set; }
    }

    public class MySurveyOptionsObject
    {
        public int Value { get; set; }
        public string DisplayText { get; set; }
    }
}
