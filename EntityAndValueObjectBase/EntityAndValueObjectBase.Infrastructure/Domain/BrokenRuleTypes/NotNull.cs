using Infrastructure.Base.Domain;

namespace EntityAndValueObjectBase.Infrastructure.Domain.BrokenRuleTypes{
    public class NotNull : BrokenRule{
        public NotNull(string propertyName){
            PropertyName = propertyName;
        }
        public override string Message{
            get { return PropertyName + " can not be null"; }
        }
    }
}