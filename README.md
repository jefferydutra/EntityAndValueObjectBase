Entity And Value Object Base
========================

Some of the base concepts/code of this project comes from the great book :  [Professional ASP.NET Design Patterns by : Scott Millett ](http://www.amazon.com/Professional-ASP-NET-Design-Patterns-Millett/dp/0470292784/ref=sr_1_8?ie=UTF8&qid=1398108813&sr=8-8&keywords=c%23+design+patterns)

The main goal of the project is to give you a base when you are working with Domain Driven Design.  

##Project Overview
1. [Entity](#entity)
2. [Value Object](#value-object)
3. [Custom Validation Checks ](#custom-validation-checks)
4. [Validate Value Object](#validate-value-object)
5. [Validate Entity Extensions](#validate-entity-extensions)
6. [IValidate Entity](#ivalidate-entity)
7. [Validate Entity Test Stub Factory](#validate-entity-test-stub-factory)

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


###Validate Entity Extensions
These are extension methods that allow you to find out if an entity is in a valid state or to throw an exeption if an entity is invalid. This currently only works with string, guid and integer ids for entities

####IsValid Method
```c#
    return entity.GetBrokenRules.HasNoBrokenRules();
```
####ThrowException Method
```c#
        ThrowException(entity.GetBrokenRules);

        private static void ThrowException(IEnumerable<BrokenRule> brokenRules){
            if (!brokenRules.Any())
            {
                return;
            }
            var message = brokenRules.GetInvalidDomainObjectExceptionMessage();
            throw new EntityIsNotValidException(message);
        }
    
```



###IValidate Entity
This provides an interface that allows you program to an interface as opposed to a concrete implementation.  The included concrete implementation ValidateEntity calls the corresponding methods from  ValidateEntityExtensions. This currently only works with string, guid and integer ids for entities
```c#
    public interface IValidateEntity
    {
        bool IsValid(EntityBase<int> entity);
        bool IsValid(EntityBase<string> entity);
        bool IsValid(EntityBase<Guid> entity);
        IEnumerable<string> GetErrorMessages(EntityBase<int> entity);
        IEnumerable<string> GetErrorMessages(EntityBase<string> entity);
        IEnumerable<string> GetErrorMessages(EntityBase<Guid> entity);
        void ThrowExceptionIfEntityIsInvalid(EntityBase<int> entity);
        void ThrowExceptionIfEntityIsInvalid(EntityBase<string> entity);
        void ThrowExceptionIfEntityIsInvalid(EntityBase<Guid> entity);
    }
```

###Validate Entity Test Stub Factory
This factory class simplifies the creation of "Test Stubs" for IValidateEntity. The only one that may seem odd is ValidateEntityInNotValidStateNoExceptionStub; the point of this one is that it allows you to perfrom state verification on your entity without having your test fail because of an exception
```c#
ValidateEntityStubFactory
    .CreateValidateEntity(ValidateEntityStubType.IsValid);
```
```c#
ValidateEntityStubFactory
    .CreateValidateEntity(ValidateEntityStubType.NotValidAndShouldNotThrowException);
```
```c#
ValidateEntityStubFactory
    .CreateValidateEntity(ValidateEntityStubType.NotValidAndThrowsException);
```
