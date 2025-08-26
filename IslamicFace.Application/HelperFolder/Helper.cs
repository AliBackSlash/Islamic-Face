namespace IslamicFace.Application.HelperFolder;
public static class Helper<T>
{
    public static Result<T> FailIfNeeded(Result check, string context)
    {
        return Result.Failure<T>(
            new Error($"{context} error", string.Join(", ", check.Errors), ErrorType.Validation));
    }

}
