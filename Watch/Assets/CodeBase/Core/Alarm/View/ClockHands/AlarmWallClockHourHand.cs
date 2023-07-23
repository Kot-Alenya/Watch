using System;

namespace CodeBase.Core.Alarm.View.ClockHands
{
    public class AlarmWallClockHourHand : AlarmWallClockHand
    {
        private const int HourCircleAngle = 360 / 12;

        private protected override TimeSpan CalculateTime(float deltaAngle)
        {
            var savedTime = AlarmPresenter.GetClockTime();
            var offset = TimeSpan.FromHours(deltaAngle / HourCircleAngle);

            return savedTime + offset;
        }
    }
}