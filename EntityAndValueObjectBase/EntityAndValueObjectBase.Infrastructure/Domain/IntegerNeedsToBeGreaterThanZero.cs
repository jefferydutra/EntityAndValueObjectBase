namespace EntityAndValueObjectBase.Infrastructure.Domain{
    public class IntegerNeedsToBeGreaterThanZero : BrokenRule{
        public IntegerNeedsToBeGreaterThanZero(string propertyName){
            PropertyName = propertyName;
        }
        public override string Message{
            get { return PropertyName + " needs to have a value greater than 0"; }
        }
    }
}