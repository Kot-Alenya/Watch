using System;

namespace CodeBase.Core.Alarm.View.ClockHands
{
    public class AlarmWallClockMinuteHand : AlarmWallClockHand
    {
        private const int MinuteCircleAngle = 360 / 60;

        private protected override TimeSpan CalculateTime(float deltaAngle)
        {
            var savedTime = AlarmPresenter.GetClockTime();
            var offset = TimeSpan.FromMinutes(deltaAngle / MinuteCircleAngle);

            return savedTime + offset;
        }
    }
}