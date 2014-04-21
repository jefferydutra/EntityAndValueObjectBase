namespace EntityAndValueObjectBase.Infrastructure.Domain{
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