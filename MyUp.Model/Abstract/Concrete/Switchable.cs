using MyUp.Model.Abstract.Interface;

namespace MyUp.Model.Abstract.Concrete
{
    public abstract class Switchable : ISwitchable
    {
        public bool Status { get; set; }
    }
}