using Infrastructure.Base.Domain;

namespace  EntityAndValueObjectBase.Infrastructure.Domain.BrokenRuleTypes{
    public class BaseBrokenRule : BrokenRule{
        private readonly string _customMessage;

        public BaseBrokenRule(string propertyName, string propertyValue, string customMessage){
            _customMessage = customMessage;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        public override string Message{
            get { return PropertyName + " | " + PropertyValue + " | " + _customMessage; }
        }
    }
} 