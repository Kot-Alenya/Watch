using System.Collections.Generic;
using CodeBase.Core.Alarm.View;
using CodeBase.Core.Clock;
using System;

namespace CodeBase.Core.Alarm
{
    public class AlarmPresenter
    {
        private readonly ClockPresenter _clockPresenter;
        private readonly List<IAlarmView> _views;
        private readonly AlarmModel _model;

        private TimeSpan _clockTime;
        private bool _isDigitalClockSelected;

        public AlarmPresenter(ClockPresenter clockPresenter, AlarmSceneData sceneData, AlarmModel model)
        {
            _clockPresenter = clockPresenter;
            _views = sceneData.GetAlarmViews();
            _model = model;
        }

        public void Initialize()
        {
            foreach (var view in _views)
                view.Initialize(this);

            _clockTime = _clockPresenter.GetCurrentTime();
        }

        public void Dispose()
        {
            foreach (var view in _views)
                view.Dispose();
        }

        public void UpdateViews()
        {
            _clockPresenter.UpdateWallClockView(_clockTime);

            if (!_isDigitalClockSelected)
                _clockPresenter.UpdateDigitalClockView(_clockTime);
        }

        public void UpdateModel() => _model.Update(_clockPresenter.GetCurrentTime());

        public void SetDigitalClockSelected(bool isSelected) => _isDigitalClockSelected = isSelected;

        public bool TryParseTime(string timeString, out TimeSpan time) => _model.TryParseTime(timeString, out time);

        public TimeSpan GetClockTime() => _clockTime;

        public void SetClockTime(TimeSpan time) => _clockTime = time;

        public void SetAlarm() => _model.SetAlarm(_clockPresenter.GetCurrentTime(), _clockTime);
    }
}