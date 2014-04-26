using System;
using EntityAndValueObjectBase.Infrastructure.Domain;

namespace EntityAndValueObjectBase.Infrastructure.Tests.EntityBaseTests.EntityStubs
{
    public class EntityStubGuidId : EntityBase<Guid>
    {
        public string TestStringProperty { get; set; }
        protected override void CheckForBrokenRules()
        {

        }
    }
}