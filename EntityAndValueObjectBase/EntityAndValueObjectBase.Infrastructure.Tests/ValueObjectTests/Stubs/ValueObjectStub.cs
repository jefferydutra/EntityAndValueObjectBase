using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.Tests.ValueObjectTests.Stubs
{
    public class ValueObjectStub : ValueObject
    {
        public string TestStringProperty { get; set; }
        protected override void CheckForBrokenRules(){
            BrokenRules
                .AddIfPropertyIsNull(TestStringProperty, () => TestStringProperty);
        }

    }
}
