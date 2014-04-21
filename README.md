EntityAndValueObjectBase
========================

Contains base information for creating and validating entities and value objects


The main goal of the project is to give you a base when you are working with Domain Driven Design.  

The base class for Entities is EntityBase<iTd>.  

```c#
    public abstract class EntityBase<TId>{
        
        private readonly IList<BrokenRule> _brokenRules = new List<BrokenRule>();
        public TId Id { get; set; }

        public IEnumerable<BrokenRule> GetBrokenRules{
            get{
                _brokenRules.Clear();
                CheckForBrokenRules();
                return _brokenRules;
            }
        }
        public IList<BrokenRule> BrokenRules {get { return _brokenRules; }} 
        protected abstract void CheckForBrokenRules();
        
    }
```
