using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs{
    public class EntityStubStringId : EntityBase<string>
    {
        public string TestStringProperty { get; set; }
        protected override void CheckForBrokenRules()
        {

        }
    }
}