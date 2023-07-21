using System;
using UnityEngine;

namespace CodeBase.Core.Clock.View
{
    public class WallClockUIView : MonoBehaviour, IClockView
    {
        private const float MillisecondsPerSecond = 1000f;
        private const float SecondsPerMinute = 60f;
        private const float MinutesPerHours = 60f;
    
        private const int SecondCircleAngle = 360 / 60;
        private const int MinuteCircleAngle = 360 / 60;
        private const int HourCircleAngle = 360 / 12;

        [SerializeField] private RectTransform _secondHand;
        [SerializeField] private RectTransform _minuteHand;
        [SerializeField] private RectTransform _hourHand;

        public void ShowTime(TimeSpan time)
        {
            var seconds = time.Seconds + time.Milliseconds / MillisecondsPerSecond;
            var minutes = time.Minutes + time.Seconds / SecondsPerMinute;
            var hours = time.Hours + time.Minutes / MinutesPerHours;

            _secondHand.rotation = GetRotation(seconds * SecondCircleAngle);
            _minuteHand.rotation = GetRotation(minutes * MinuteCircleAngle);
            _hourHand.rotation = GetRotation(hours * HourCircleAngle);
        }

        private Quaternion GetRotation(float angle)
            => Quaternion.AngleAxis(angle, Vector3.back);
    }
}