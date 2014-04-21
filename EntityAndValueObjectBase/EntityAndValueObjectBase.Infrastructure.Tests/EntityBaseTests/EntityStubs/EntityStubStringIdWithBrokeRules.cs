using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs{
    public class EntityStubStringIdWithBrokeRules : EntityBase<string>{
        public string TestStringProperty { get; set; }

        protected override void CheckForBrokenRules(){
            TestStringProperty = null;
            BrokenRules
                .AddIfPropertyIsNull(TestStringProperty, () => TestStringProperty);
        }
    }
}