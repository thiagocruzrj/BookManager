using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BookManager.Core.DomainObjects
{
    public class Validations
    {
        public static void EqualsValidade(object object1, object object2, string message)
        {
            if (!object1.Equals(object2)) throw new DomainException(message);
        }

        public static void DifferentValidade(object object1, object object2, string message)
        {
            if (object1.Equals(object2)) throw new DomainException(message);
        }

        public static void CharactersValidade(string value, int max, string message)
        {
            var length = value.Trim().Length;
            if (length > max) throw new DomainException(message);
        }

        public static void CharactersValidadeMinMaxString(string value, int min, int max, string message)
        {
            var length = value.Trim().Length;
            if (length < min || length > max) throw new DomainException(message);
        }

        public static void ExpressionValidade(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);
            if (!regex.IsMatch(value)) throw new DomainException(message);
        }

        public static void ValidateIfEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0) throw new DomainException(message); 
        }

        public static void ValidateIfNull(object object1, string message)
        {
            if (object1 == null) throw new DomainException(message);
        }

        public static void CharactersValidadeMinMaxDouble(double value, double min, double max, string message)
        {
            if (value < min || value > max) throw new DomainException(message);
        }

        public static void CharactersValidadeMinMaxFloat(float value, float min, float max, string message)
        {
            if (value < min || value > max) throw new DomainException(message);
        }

        public static void CharactersValidadeMinMaxInt(int value, int min, int max, string message)
        {
            if (value < min || value > max) throw new DomainException(message);
        }

        public static void CharactersValidadeMinMaxLong(long value, long min, long max, string message)
        {
            if (value < min || value > max) throw new DomainException(message);
        }

        public static void CharactersValidadeMinMaxDecimal(decimal value, decimal min, decimal max, string message)
        {
            if (value < min || value > max) throw new DomainException(message);
        }
        public static void ValidateIfLessThanLong(long value, long min, string message)
        {
            if (value < min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThanDouble(double value, double min, string message)
        {
            if (value < min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThanDecimal(decimal value, decimal min, string message)
        {
            if (value < min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThanInt(int value, int min, string message)
        {
            if (value < min)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfFalse(bool boolvalue, string message)
        {
            if (!boolvalue)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfTrue(bool boolvalue, string message)
        {
            if (boolvalue)
            {
                throw new DomainException(message);
            }
        }
    }
}
