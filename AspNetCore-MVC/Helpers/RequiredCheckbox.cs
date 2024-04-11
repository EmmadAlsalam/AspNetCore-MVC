﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Helpers;

public class RequiredCheckbox : ValidationAttribute
{
    public override bool IsValid(object? value) => value is bool b && b;
}
