using System;
using TMPro;
using UnityEngine;

namespace CodeBase.Core.Clock.View
{
    public class DigitalClockUIView : MonoBehaviour, IClockView
    {
        [SerializeField] private TextMeshProUGUI _timeText;

        public void ShowTime(TimeSpan time) =>
            _timeText.text = $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}";
    }
}