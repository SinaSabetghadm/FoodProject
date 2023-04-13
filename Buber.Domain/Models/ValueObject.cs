﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buber.Domain.Models
{
    public abstract class ValueObject:IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) { return false; }
            
            var valueObject= obj as ValueObject;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents()); 
        }


        public static bool operator ==(ValueObject left, ValueObject right) { return Equals(left, right); }
        public static bool operator !=(ValueObject left, ValueObject right) { return !Equals(left, right); }
        public override int GetHashCode()
        {
            return GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object) other);
        }
    }
    public class Price: ValueObject
    {
        public decimal Amount { get; private set; } 
        public string Currency { get; private set; }
        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();    
        }
    }
}