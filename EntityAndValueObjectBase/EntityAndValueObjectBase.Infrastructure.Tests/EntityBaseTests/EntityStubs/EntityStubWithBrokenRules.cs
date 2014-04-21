using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs
{
    public class EntityStubWithBrokenRules : EntityBase<int>
    {
        public string TestStringProperty { get; set; }
        public int TestIntProperty { get; set; }
        protected override void CheckForBrokenRules(){
            BrokenRules
                .AddBrokenRuleIfPropertyIsNull(TestStringProperty, () => TestStringProperty);
            BrokenRules
                .AddBrokenRuleIfPropertyEmpty(TestStringProperty, () => TestStringProperty);
            BrokenRules
                .AddBrokenRuleIfIntegerPropertyLessThanOne(TestIntProperty,() => TestIntProperty);
        }

    }
}
