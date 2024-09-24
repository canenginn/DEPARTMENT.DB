#region Result
public class Result : IResult
{

    public Result()
    {

    }
    public Result(ResultStatus resultStatus)
    {
        ResultStatus = resultStatus;
    }
    public Result(ResultStatus resultStatus, string messages)
    {
        ResultStatus = resultStatus;
        Message = messages;
    }
    public Result(ResultStatus resultStatus, string messages, Exception exception)
    {
        ResultStatus = resultStatus;
        Message = messages;
        Exception = exception;
    }

    public ResultStatus ResultStatus { get; }
    public string Message { get; }
    public Exception Exception { get; }
}
#endregion