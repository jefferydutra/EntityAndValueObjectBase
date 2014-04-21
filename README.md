EntityAndValueObjectBase
========================

Some of the base conepts/code of this project comes from the great book :  [Professional ASP.NET Design Patterns by : Scott Millett ](http://www.amazon.com/Professional-ASP-NET-Design-Patterns-Millett/dp/0470292784/ref=sr_1_8?ie=UTF8&qid=1398108813&sr=8-8&keywords=c%23+design+patterns)

The main goal of the project is to give you a base when you are working with Domain Driven Design.  

The base class for Entities is EntityBase<TId>.  This class includes

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
