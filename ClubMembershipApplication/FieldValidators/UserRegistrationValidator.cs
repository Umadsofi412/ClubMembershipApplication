using FieldValidatorAPI;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FieldValidators
{
    public class UserRegistrationValidator:IFieldValidator
    {
        const int FirstName_Min_Length = 2;
        const int FirstName_Max_length = 100;
        const int LastName_Min_Length = 2;
        const int LastName_Max_length = 100;

        delegate bool EmailEixtsDel(string emailAddress);

        FieldValidatoeDel _fieldValidatorDel = null;
        RequiredValidDel _requiredValidDel = null;
        StringLengthValidDel _stringlengthValidDel = null;
        DateValidDel _dateValidDel = null;
        PatternMatchDel _patternMatchValidDel = null;
        CompareFieldsValidDel _compareFieldsValidDel = null;

        EmailEixtsDel _emailExistsDel = null;

        string[] _fieldArray = null;
        public string[] FieldArray
        {
            get
            {
                if(_fieldArray == null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length]);

                    return _fieldArray;
                }
            }
        }

        public FieldValidatoeDel ValidatorDel => throw new NotImplementedException();

        public void InitialiseValidatorDelegates()
        {

            _fieldValidatorDel = new FieldValidatoeDel(ValidField);
            _requiredValidDel = CommonFiledValidatorFunctions.RequiredFieldValidDel;
            _stringlengthValidDel = CommonFiledValidatorFunctions.StringLengthFieldValidDel;
            _dateValidDel = CommonFiledValidatorFunctions.DateFieldValidDel;
            _patternMatchValidDel = CommonFiledValidatorFunctions.PatternMatchValidDel;
            _compareFieldsValidDel = CommonFiledValidatorFunctions.FieldsCompareValidDel;

        }
        
        public bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = "";

            FieldConstants.UserRegistrationField userRegistrationField  =  (FieldConstants.UserRegistrationField)fieldIndex;
            switch (userRegistrationField)
            {   
                case FieldConstants.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue))? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}"  :"";

            }

            return (fieldInvalidMessage == " ");
        }
    }
}
