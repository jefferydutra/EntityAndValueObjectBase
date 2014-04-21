using EntityAndValueObjectBase.Infrastructure.Tests.ValueObjectTests.Stubs;
using Ploeh.AutoFixture;

namespace EntityAndValueObjectBase.Infrastructure.Tests.Create{
    public static class ValueObjectCreate{
        public static ValueObjectStub Anonymous(){
            return new Fixture().Create<ValueObjectStub>();
        }

        public static ValueObjectStubWithBrokeRules AnonymousWithBrokenRules()
        {
            return new Fixture().Create<ValueObjectStubWithBrokeRules>();
        }
    }
}