using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs
{
    public class EntityStub : EntityBase<int>
    {
        public string TestStringProperty { get; set; }
        public int TestIntProperty { get; set; }
        protected override void CheckForBrokenRules(){
            BrokenRules
                .AddIfPropertyIsNull(TestStringProperty, () => TestStringProperty);
            BrokenRules
                .AddIfPropertyEmpty(TestStringProperty, () => TestStringProperty);
            BrokenRules
                .AddIfIntegerPropertyLessThanOne(TestIntProperty,() => TestIntProperty);
        }

    }
}
