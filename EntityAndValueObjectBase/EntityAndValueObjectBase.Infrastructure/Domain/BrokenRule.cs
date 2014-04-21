namespace EntityAndValueObjectBase.Infrastructure.Domain{
    public abstract class BrokenRule{
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public abstract string Message { get; }
    }
}