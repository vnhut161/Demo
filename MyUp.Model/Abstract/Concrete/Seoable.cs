using MyUp.Model.Abstract.Interface;

namespace MyUp.Model.Abstract.Concrete
{
    public abstract class Seoable : ISeoable
    {
        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }
    }
}