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
        }

        public void Dispose()
        {
            foreach (var view in _views)
                view.Dispose();
        }

        public void UpdateViews()
        {
            _clockPresenter.UpdateWallClockView();

            if (!_isDigitalClockSelected)
                _clockPresenter.UpdateDigitalClockView();
        }

        public void UpdateModel() => _model.Update(_clockPresenter.GetCurrentTime());

        public void SetDigitalClockSelected(bool isSelected) => _isDigitalClockSelected = isSelected;

        public bool IsCanParseTime(string timeString) => _model.IsCanParseTime(timeString);

        public TimeSpan ParseTime(string timeString) => _model.ParseTime(timeString);

        public TimeSpan GetCurrentTime() => _clockPresenter.GetCurrentTime();

        public void SetAlarmTime(TimeSpan time)
        {
            _clockPresenter.SetCurrentTime(time);
            _model.SetAlarmTime(time);
        }
    }
}