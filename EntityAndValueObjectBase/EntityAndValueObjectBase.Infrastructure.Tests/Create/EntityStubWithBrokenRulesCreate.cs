using EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs;
using Ploeh.AutoFixture;

namespace EntityAndValueObjectBase.Infrastructure.Tests.Create
{
    public static class EntityStubWithBrokenRulesCreate
    {
        public static EntityStubWithBrokenRules Anonymous(){
            return new Fixture().Create<EntityStubWithBrokenRules>();
        }
    }
}
