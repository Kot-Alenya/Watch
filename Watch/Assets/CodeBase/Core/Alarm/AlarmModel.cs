using System;
using System.Text.RegularExpressions;
using CodeBase.Infrastructure.Services.Log;

namespace CodeBase.Core.Alarm
{
    public class AlarmModel
    {
        private const string TimeParsePattern = "[0-9]{2}:[0-9]{2}:[0-9]{2}";
        private const char TimeSplitter = ':';
        private const int TimeNumbersLength = 8;
        private const int MaxHoursNumber = 24;
        private const int MaxHMinutesNumber = 60;
        private const int MaxSecondsNumber = 60;

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

        public void SetAlarm(TimeSpan currenTime, TimeSpan alarmTime)
        {
            if (alarmTime <= currenTime)
                return;

            _logger.Log($"Alarm is set to: {alarmTime}");

            _timeToAlarm = alarmTime;
        }

        public bool TryParseTime(string timeString, out TimeSpan time)
        {
            time = default;

            try
            {
                var textNumbers = timeString.Split(TimeSplitter);
                var parsedNumbers = new[]
                {
                    int.Parse(textNumbers[0]),
                    int.Parse(textNumbers[1]),
                    int.Parse(textNumbers[2]),
                };

                time = new TimeSpan(parsedNumbers[0], parsedNumbers[1], parsedNumbers[2]);

                return _timeParser.IsMatch(timeString) &&
                       timeString.Length == TimeNumbersLength &&
                       parsedNumbers[0] < MaxHoursNumber &&
                       parsedNumbers[1] < MaxHMinutesNumber &&
                       parsedNumbers[2] < MaxSecondsNumber;
            }
            catch
            {
                return false;
            }
        }
    }
}