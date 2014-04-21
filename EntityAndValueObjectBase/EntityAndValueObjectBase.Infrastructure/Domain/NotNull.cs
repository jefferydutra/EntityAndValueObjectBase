namespace EntityAndValueObjectBase.Infrastructure.Domain{
    public class NotNull : BrokenRule{
        public NotNull(string propertyName){
            PropertyName = propertyName;
        }
        public override string Message{
            get { return PropertyName + " can not be null"; }
        }
    }
}