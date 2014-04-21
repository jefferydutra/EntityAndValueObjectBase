Entity And Value Object Base
========================

Some of the base concepts/code of this project comes from the great book :  [Professional ASP.NET Design Patterns by : Scott Millett ](http://www.amazon.com/Professional-ASP-NET-Design-Patterns-Millett/dp/0470292784/ref=sr_1_8?ie=UTF8&qid=1398108813&sr=8-8&keywords=c%23+design+patterns)

The main goal of the project is to give you a base when you are working with Domain Driven Design.  

##Entity
The base class for Entities is EntityBase<TId>.  This class includes an Id property using genercis so that you can use whatever type you want.  It also inludes an abstract CheckForBrokenRules where you ensure your entity is valid.

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

##Value Object
The base class for Value Objects  is ValueObject  This class includes an abstract CheckForBrokenRules where you ensure your value object is valid.

```c#
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
```
##Custom Validation Checks
There are some built in custom validation checks that will add built-in broken rule objects to an entity's broken rule list

```c#
        protected override void CheckForBrokenRules(){
            BrokenRules
                .AddIfPropertyIsNull(TestStringProperty, () => TestStringProperty);
            BrokenRules
                .AddIfPropertyEmpty(TestStringProperty, () => TestStringProperty);
            BrokenRules
                .AddIfIntegerPropertyLessThanOne(TestIntProperty,() => TestIntProperty);
        }
```
