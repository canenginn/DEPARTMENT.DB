#region DataResult
public class DataResult<T> : IDataResult<T>
{
    public DataResult(ResultStatus resultStatus, T data)
    {
        ResultStatus = resultStatus;
        Data = data;
    }

    public DataResult(ResultStatus resultStatus, string message)
    {
        ResultStatus = resultStatus;
        Message = message;
    }
    public DataResult(ResultStatus resultStatus, string message, T data)
    {
        ResultStatus = resultStatus;
        Message = message;
        Data = data;
    }
    public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
    {
        ResultStatus = resultStatus;
        Message = message;
        Data = data;
        Exception = exception;
    }


    public T Data { get; }

    public ResultStatus ResultStatus { get; }

    public string Message { get; }

    public Exception Exception { get; }
}
#endregion