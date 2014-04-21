using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.Tests.ValueObjectTests.Stubs{
    public class ValueObjectStubWithBrokeRules : ValueObject
    {
        public string TestStringProperty { get; set; }
        protected override void CheckForBrokenRules()
        {
            TestStringProperty = null;
            BrokenRules
                .AddIfPropertyIsNull(TestStringProperty, () => TestStringProperty);
        }

    }
}