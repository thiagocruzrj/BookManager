using System;
using System.Text.RegularExpressions;

namespace BookManager.Core.DomainObjects
{
    public class Validations
    {
        public static void EqualsValidate(object object1, object object2, string message)
        {
            if (object1.Equals(object2)) throw new DomainException(message);
        }

        public static void DifferentValidate(object object1, object object2, string message)
        {
            if (!object1.Equals(object2)) throw new DomainException(message);
        }

        public static void CharactersValidate(string value, int max, string message)
        {
            var length = value.Trim().Length;
            if (length > max) throw new DomainException(message);
        }

        public static void CharactersValidateMinMaxString(string value, int min, int max, string message)
        {
            var length = value.Trim().Length;
            if (length < min || length > max) throw new DomainException(message);
        }

        public static void ExpressionValidate(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);
            if (!regex.IsMatch(value)) throw new DomainException(message);
        }

        public static void ValidateIfAgeIsGreaterThan30(DateTime birthdate, string message)
        {
            var YearBase = DateTime.Today.Year - 30;
            if(birthdate.Year >= YearBase) throw new DomainException(message);
        }

        public static void ValidateIfEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0) throw new DomainException(message); 
        }

        public static void ValidateIfNull(object object1, string message)
        {
            if (object1 == null) throw new DomainException(message);
        }

        public static void CharactersValidateMinMaxDouble(double value, double min, double max, string message)
        {
            if (value < min || value > max) throw new DomainException(message);
        }

        public static void CharactersValidateMinMaxFloat(float value, float min, float max, string message)
        {
            if (value < min || value > max) throw new DomainException(message);
        }

        public static void CharactersValidateMinMaxInt(int value, int min, int max, string message)
        {
            if (value < min || value > max) throw new DomainException(message);
        }

        public static void CharactersValidateMinMaxLong(long value, long min, long max, string message)
        {
            if (value < min || value > max) throw new DomainException(message);
        }

        public static void CharactersValidateMinMaxDecimal(decimal value, decimal min, decimal max, string message)
        {
            if (value < min || value > max) throw new DomainException(message);
        }
        public static void ValidateIfLessThanLong(long value, long min, string message)
        {
            if (value < min) throw new DomainException(message);
        }

        public static void ValidateIfLessThanDouble(double value, double min, string message)
        {
            if (value < min) throw new DomainException(message);
        }

        public static void ValidateIfLessThanDecimal(decimal value, decimal min, string message)
        {
            if (value < min) throw new DomainException(message);
        }

        public static void ValidateIfLessThanInt(int value, int min, string message)
        {
            if (value < min) throw new DomainException(message);
        }

        public static void ValidateIfFalse(bool boolvalue, string message)
        {
            if (!boolvalue) throw new DomainException(message);
        }

        public static void ValidateIfTrue(bool boolvalue, string message)
        {
            if (boolvalue) throw new DomainException(message);
        }
    }
}
