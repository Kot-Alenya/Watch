using System;

namespace CodeBase.Core.Alarm.View.ClockHands
{
    public class AlarmWallClockSecondHand : AlarmWallClockHand
    {
        private const int SecondCircleAngle = 360 / 60;

        private protected override void OnHandDrag(float deltaAngle)
        {
            var savedTime = AlarmPresenter.GetCurrentTime();
            var offset = TimeSpan.FromSeconds(deltaAngle / SecondCircleAngle);

            AlarmPresenter.SetAlarmTime(savedTime + offset);
        }
    }
}