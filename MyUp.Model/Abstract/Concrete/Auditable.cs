﻿using MyUp.Model.Abstract.Interface;
using System;

namespace MyUp.Model.Abstract.Concrete
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}