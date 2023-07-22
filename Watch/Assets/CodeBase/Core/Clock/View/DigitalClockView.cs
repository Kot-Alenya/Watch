using System;
using TMPro;
using UnityEngine;

namespace CodeBase.Core.Clock.View
{
    public class DigitalClockView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _timeInputField;

        public void ShowTime(TimeSpan time) =>
            _timeInputField.text = $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}";
    }
}