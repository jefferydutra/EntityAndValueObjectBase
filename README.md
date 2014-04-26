Entity And Value Object Base
========================

Some of the base concepts/code of this project comes from the great book :  [Professional ASP.NET Design Patterns by : Scott Millett ](http://www.amazon.com/Professional-ASP-NET-Design-Patterns-Millett/dp/0470292784/ref=sr_1_8?ie=UTF8&qid=1398108813&sr=8-8&keywords=c%23+design+patterns)

The main goal of the project is to give you a base when you are working with Domain Driven Design.  

##Project Overview
1. [Entity](#entity)
2. [Value Object](#value-object)
3. [Custom Validation Checks ](#custom-validation-checks)
4. [Validate Entity Extensions](#validate-entity-extensions)
5. [Validate Value Object](#validate-value-object)

###Entity
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

###Value Object
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
###Custom Validation Checks
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

###Validate Entity Extensions
These are extension methods that allow you to find out if an entity is in a valid state or to throw an exeption if an entity is invalid. This currently only works with string, guid and integer ids for entities
```c#
    public static class ValidateEntityExtensions{
        public static bool IsValid(this EntityBase<int> entity)
        {
            return entity.GetBrokenRules.HasNoBrokenRules();
        }
        public static bool IsValid(this EntityBase<string> entity)
        {
            return entity.GetBrokenRules.HasNoBrokenRules();
        }

        public static bool IsValid(this EntityBase<Guid> entity)
        {
            return entity.GetBrokenRules.HasNoBrokenRules();
        }

        public static void ThrowExceptionIfEntityIsInvalid(this EntityBase<int> entity){
            ThrowException(entity.GetBrokenRules);
        }
        public static void ThrowExceptionIfEntityIsInvalid(this EntityBase<string> entity){
            ThrowException(entity.GetBrokenRules);
        }
        public static void ThrowExceptionIfEntityIsInvalid(this EntityBase<Guid> entity)
        {
            ThrowException(entity.GetBrokenRules);
        }

        private static void ThrowException(IEnumerable<BrokenRule> brokenRules){
            if (!brokenRules.Any())
            {
                return;
            }
            var message = brokenRules.GetInvalidDomainObjectExceptionMessage();
            throw new EntityIsNotValidException(message);
        }
    }
```


###Validate Value Object
These are extension methods that allow you to find out if a Value Object is in a valid state or to throw an exeption if invalid. 
```c#
    public static class ValidateValueObject{

        public static bool IsValid(this ValueObject valueObject)
        {
            return valueObject.GetBrokenRules.HasNoBrokenRules();
        }
        public static void ThrowExceptionIfEntityIsInvalid(this ValueObject valueObject)
        {
            ThrowException(valueObject.GetBrokenRules);
        }
        private static void ThrowException(IEnumerable<BrokenRule> brokenRules)
        {
            if (!brokenRules.Any())
            {
                return;
            }
            var message = brokenRules.GetInvalidDomainObjectExceptionMessage();
            throw new ValueObjectIsNotValidException(message);
        }
    }

```
