﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLservice.ServiceData
{
    public class BuildingRoomObject
    {
        public BuildingRoomObject() { }

        public int PK_BuildingRoom_Id { get; set; }
        public int FK_Building_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string Name_Short { get; set; }
        public string Name_Long { get; set; }
        public string Description { get; set; }
        public string RentPaymentFrequency { get; set; }
        public decimal RentPaymentAmount { get; set; }

    }

    public class BuildingRoomObjectRow
    {
        public int PK_BuildingRoom_Id { get; set; }
        public int FK_Building_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string Name_Short { get; set; }
        public string Name_Long { get; set; }
        public string Description { get; set; }
        public string RentPaymentFrequency { get; set; }
        public decimal RentPaymentAmount { get; set; }
    }
}
