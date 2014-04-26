namespace EntityAndValueObjectBase.Infrastructure.Domain.BrokenRuleTypes{
    public class NotEmptyString : BrokenRule{

        public NotEmptyString(string propertyName){
            PropertyName = propertyName;
        }

        public override string Message{
            get { return PropertyName + " can not be an empty string"; }
        }
    }
}