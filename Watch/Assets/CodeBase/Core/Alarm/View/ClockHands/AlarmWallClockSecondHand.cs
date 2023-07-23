using System;

namespace CodeBase.Core.Alarm.View.ClockHands
{
    public class AlarmWallClockSecondHand : AlarmWallClockHand
    {
        private const int SecondCircleAngle = 360 / 60;

        private protected override TimeSpan CalculateTime(float deltaAngle)
        {
            var savedTime = AlarmPresenter.GetClockTime();
            var offset = TimeSpan.FromSeconds(deltaAngle / SecondCircleAngle);

            return savedTime + offset;
        }
    }
}