using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class WhatHappenedName : WhatHappened
{
    public override string GetWhatHappenedName(WhatHappenedStatus value)
    {
        string[] enumFieldNames = Enum.GetNames(typeof(WhatHappenedStatus));

        foreach (string fieldName in enumFieldNames)
        {
            var enumValue = (WhatHappenedStatus)Enum.Parse(typeof(WhatHappenedStatus), fieldName);

            if (enumValue == value)
            {
                return fieldName;
            }
        }

        throw new ServicesInvalidOperationException(nameof(GetWhatHappenedName));
    }
}