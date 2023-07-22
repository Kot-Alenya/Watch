using System;

namespace CodeBase.Core.Alarm.View.ClockHands
{
    public class AlarmWallClockMinuteHand : AlarmWallClockHand
    {
        private const int MinuteCircleAngle = 360 / 60;

        private protected override void OnHandDrag(float deltaAngle)
        {
            var savedTime = AlarmPresenter.GetCurrentTime();
            var offset = TimeSpan.FromMinutes(deltaAngle / MinuteCircleAngle);

            AlarmPresenter.SetAlarmTime(savedTime + offset);
        }
    }
}