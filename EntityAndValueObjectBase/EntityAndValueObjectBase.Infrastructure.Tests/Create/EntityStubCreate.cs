using EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs;
using Ploeh.AutoFixture;

namespace EntityAndValueObjectBase.Infrastructure.Tests.Create
{
    public static class EntityStubCreate
    {
        public static EntityStub Anonymous(){
            return new Fixture().Create<EntityStub>();
        }
        public static EntityStubIntIdWithBrokeRules AnonymousWithBrokenRules()
        {
            return new Fixture().Create<EntityStubIntIdWithBrokeRules>();
        }

        public static EntityStubStringIdWithBrokeRules AnonymousStringIdWithBrokenRules()
        {
            return new Fixture().Create<EntityStubStringIdWithBrokeRules>();
        }

        public static EntityStubStringId AnonymousStringId()
        {
            return new Fixture().Create<EntityStubStringId>();
        }
    }
}
