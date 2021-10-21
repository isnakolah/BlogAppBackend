namespace Blog.Common.Models.ServiceResult
{
    /// <summary>
    /// Create a service result
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }

        public ServiceResult()
        {
        }

        public ServiceResult(T data)
        {
            Data = data;
        }

        public ServiceResult(T data, ServiceError error) : base(error)
        {
            Data = data;
        }

        public ServiceResult(ServiceError error) : base(error)
        {
        }
    }

    public class ServiceResult
    {
        public bool Succeeded => Error == null;

        public ServiceError Error { get; set; }

        public ServiceResult()
        {
        }

        public ServiceResult(ServiceError error)
        {
            if (error is null)
                error = ServiceError.DefaultError;

            Error = error;
        }

        #region Helper Methods

        public static ServiceResult Failed(ServiceError error)
        {
            return new ServiceResult(error);
        }

        public static ServiceResult<T> Failed<T>(ServiceError error)
        {
            return new ServiceResult<T>(error);
        }

        public static ServiceResult<T> Failed<T>(T data, ServiceError error)
        {
            return new ServiceResult<T>(data, error);
        }

        public static ServiceResult<T> Success<T>(T data)
        {
            return new ServiceResult<T>(data);
        }

        public static ServiceResult Success()
        {
            return new ServiceResult();
        }

        #endregion
    }
}
