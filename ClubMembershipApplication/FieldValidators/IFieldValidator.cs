﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FieldValidators
{
    public delegate bool FieldValidatoeDel(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage);

    public interface IFieldValidator
    {
        void InitialiseValidatorDelegates();
        string[] FieldArray { get; }

       FieldValidatoeDel ValidatorDel { get; }

    }
}
