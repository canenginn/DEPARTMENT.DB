#region IDataResult
	public interface IDataResult<out  T> : IResult
	{
		public T Data { get; }
	}

#endregion