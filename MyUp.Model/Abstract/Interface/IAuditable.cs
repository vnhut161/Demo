using System;
using System.ComponentModel.DataAnnotations;

namespace MyUp.Model.Abstract.Interface
{
    public interface IAuditable
    {
        DateTime? CreatedDate { set; get; }

        [MaxLength(256)]
        string CreatedBy { set; get; }

        DateTime? UpdatedDate { set; get; }

        [MaxLength(256)]
        string UpdatedBy { set; get; }
    }
}