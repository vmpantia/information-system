
namespace IS.Logger.Contractors
{
    public interface ILogger
    {
        Task WriteErrorLog(string message, Exception exception);
        Task WriteInfoLog(string message);
        Task WriteWarnLog(string message);
    }
}