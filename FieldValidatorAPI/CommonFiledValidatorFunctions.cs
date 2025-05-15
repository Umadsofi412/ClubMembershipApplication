using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
    public delegate bool PatternMatchDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);
    public class CommonFiledValidatorFunctions
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchDel _patternMatchDel = null;
        private static CompareFieldsValidDel _compareFieldDel = null;

        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);

                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthFieldValidDel
        {
            get
            {
                if (_stringLengValidDel == null)
                    _stringLengValidDel = new StringLengthValidDel(StringFieldLengthValid);

                return _stringLengValidDel;
            }
        }

        public static DateValidDel DateFieldValidDel
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);

                return _dateValidDel;
            }
        }

        public static PatternMatchDel PatternMatchValidDel
        {
            get
            {
                if (_patternMatchDel == null)
                    _patternMatchDel = new PatternMatchDel(FieldPatternValid);

                return _patternMatchDel;
            }
        }

        public static CompareFieldsValidDel FieldsCompareValidDel
        {
            get
            {
                if (_compareFieldDel == null)
                    _compareFieldDel = new CompareFieldsValidDel(FieldComparisonValid);

                return _compareFieldDel;
            }
        }


        private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            return false;
        }

        private static bool StringFieldLengthValid(string fieldVal , int min , int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
            {
                return true;   
            }
            return false;
        }

        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if(DateTime.TryParse(dateTime, out validDateTime))
            {
                return true;
            }
            return false;
        }

        private static bool FieldPatternValid(string fieldVal , string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);
            if(regex.IsMatch(fieldVal))
            {
                return true;
            }
            return false;

        }

        private static bool FieldComparisonValid(string field1,string field2)
        {
            if(field1.Equals(field2))
                return true;
            return false;
        }


    }
}
