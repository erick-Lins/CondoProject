namespace CondoProj.Helper
{
    public class Result
    {
        public bool Success { get; }
        public string ErrorMessage { get; }

        private Result(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
        
        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result Fail(string error)
        {
            return new Result(false, error ?? throw new ArgumentNullException(nameof(error)));
        }

    }
}
