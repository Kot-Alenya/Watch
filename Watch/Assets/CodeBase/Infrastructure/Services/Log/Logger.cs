namespace CodeBase.Infrastructure.Services.Log
{
    public class Logger : ILogger
    {
        public void Log(string message) => UnityEngine.Debug.Log(message);
    }
}