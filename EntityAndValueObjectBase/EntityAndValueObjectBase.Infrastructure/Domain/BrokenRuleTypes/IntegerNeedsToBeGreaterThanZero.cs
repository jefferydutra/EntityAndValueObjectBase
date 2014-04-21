using Infrastructure.Base.Domain;

namespace EntityAndValueObjectBase.Infrastructure.Domain.BrokenRuleTypes{
    public class IntegerNeedsToBeGreaterThanZero : BrokenRule{
        public IntegerNeedsToBeGreaterThanZero(string propertyName){
            PropertyName = propertyName;
        }
        public override string Message{
            get { return PropertyName + " needs to have a value greater than 0"; }
        }
    }
}