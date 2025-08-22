namespace IslamicFace.Domain.ErrorHandleClasses;

public enum ErrorType
{
    Failure = 0,
    Validation,
    Problem ,
    NotFound ,
    Conflict,
    ConfirmEmailError,
    Delete,
    Create
}
