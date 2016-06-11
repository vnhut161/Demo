using System.ComponentModel.DataAnnotations;

namespace MyUp.Model.Abstract.Interface
{
    public interface ISeoable
    {
        [MaxLength(256)]
        string MetaKeyword { get; set; }

        [MaxLength(256)]
        string MetaDescription { get; set; }
    }
}