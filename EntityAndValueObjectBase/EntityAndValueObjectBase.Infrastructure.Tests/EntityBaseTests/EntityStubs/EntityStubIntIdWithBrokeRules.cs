using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs{
    public class EntityStubIntIdWithBrokeRules : EntityBase<int>
    {
        public string TestStringProperty { get; set; }
        public int TestIntProperty { get; set; }
        protected override void CheckForBrokenRules(){
            TestStringProperty = null;
            BrokenRules
                .AddIfPropertyIsNull(TestStringProperty, () => TestStringProperty);
        }

    }
}