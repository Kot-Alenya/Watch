using System;
using System.Collections.Generic;
using CodeBase.Core.Alarm.View;
using CodeBase.Core.Alarm.View.ClockHands;
using UnityEngine;

namespace CodeBase.Core.Alarm
{
    [Serializable]
    public class AlarmSceneData
    {
        [SerializeField] private AlarmWallClockSecondHand _wallClockSecondHand;
        [SerializeField] private AlarmWallClockMinuteHand _wallClockMinuteHand;
        [SerializeField] private AlarmWallClockHourHand _wallClockHourHand;
        [SerializeField] private AlarmDigitalClockInput _digitalClockInput;
        [SerializeField] private AlarmToggle _alarmToggle;

        public AlarmToggle AlarmToggle => _alarmToggle;
        
        public List<IAlarmView> GetAlarmViews()
        {
            var views = new List<IAlarmView>
            {
                _wallClockSecondHand,
                _wallClockMinuteHand,
                _wallClockHourHand,
                _digitalClockInput
            };

            return views;
        }
    }
}