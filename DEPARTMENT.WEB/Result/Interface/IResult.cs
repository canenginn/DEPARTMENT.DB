#region IResult
	public interface IResult
	{
		public ResultStatus ResultStatus { get; }
		public string Message { get; }
		//public Exception Exception { get; }

	}


#endregion