using MyUp.Model.Abstract.Interface;
using System;

namespace MyUp.Model.Abstract
{
    public abstract class AbsAudiSeoSwitch : IAuditable, ISwitchable, ISeoable
    {
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
    }
}