using System;

namespace CodeBase.Core.Alarm.View.ClockHands
{
    public class AlarmWallClockHourHand : AlarmWallClockHand
    {
        private const int HourCircleAngle = 360 / 12;

        private protected override void OnHandDrag(float deltaAngle)
        {
            var savedTime = AlarmPresenter.GetCurrentTime();
            var offset = TimeSpan.FromHours(deltaAngle / HourCircleAngle);

            AlarmPresenter.SetAlarmTime(savedTime + offset);
        }
    }
}