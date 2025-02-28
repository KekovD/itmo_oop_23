﻿namespace Lab5.Application.Exceptions;

internal class CurrentCustomerManagerNullException : NullReferenceException
{
    public CurrentCustomerManagerNullException()
        : base("Current customer is null")
    {
    }

    public CurrentCustomerManagerNullException(string message)
        : base(message)
    {
    }

    public CurrentCustomerManagerNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}