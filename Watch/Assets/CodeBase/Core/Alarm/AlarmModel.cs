using System;
using System.Text.RegularExpressions;
using CodeBase.Infrastructure.Services.Log;

namespace CodeBase.Core.Alarm
{
    public class AlarmModel
    {
        private const string TimeParsePattern = "[0-2]{1}[0-4]{1}" + ":[0-6]{1}[0-9]{1}" + ":[0-6]{1}[0-9]{1}";
        private const char TimeSplitter = ':';

        private readonly Regex _timeParser;
        private readonly ILogger _logger;
        private TimeSpan _timeToAlarm = TimeSpan.MaxValue;

        public AlarmModel(ILogger logger)
        {
            _timeParser = new Regex(TimeParsePattern);
            _logger = logger;
        }

        public void Update(TimeSpan currentTime)
        {
            if (_timeToAlarm > currentTime)
                return;

            _logger.Log("Alarm ringing...");
            _timeToAlarm = TimeSpan.MaxValue;
        }

        public void SetAlarmTime(TimeSpan time) => _timeToAlarm = time;

        public bool IsCanParseTime(string timeString) => _timeParser.IsMatch(timeString);

        public TimeSpan ParseTime(string timeString)
        {
            var numbers = timeString.Split(TimeSplitter);

            return new TimeSpan(
                int.Parse(numbers[0]),
                int.Parse(numbers[1]),
                int.Parse(numbers[2]));
        }
    }
}