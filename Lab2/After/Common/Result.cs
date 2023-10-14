namespace After.Common
{
    public class Result<T> where T : class
    {
        private Result(bool isSucces, T value, string error)
        {
            IsSucces = isSucces;
            Value = value;
            Error = error;
        }

        public bool IsSucces { get; }
        public T Value { get; }
        public string Error { get; }


        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, null!);
        }

        public static Result<T> Failure(string error)
        {
            return new Result<T>(false, null!, error);
        }
    }
}
