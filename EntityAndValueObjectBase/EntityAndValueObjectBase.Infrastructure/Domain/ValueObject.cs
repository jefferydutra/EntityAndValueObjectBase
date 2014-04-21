using System.Collections.Generic;

namespace EntityAndValueObjectBase.Infrastructure.Domain{
    public abstract class ValueObject{
        private readonly IList<BrokenRule> _brokenRules = new List<BrokenRule>();

        public IEnumerable<BrokenRule> GetBrokenRules
        {
            get
            {
                _brokenRules.Clear();
                CheckForBrokenRules();
                return _brokenRules;
            }
        }
        public IList<BrokenRule> BrokenRules { get { return _brokenRules; } }
        protected abstract void CheckForBrokenRules();
    }
}