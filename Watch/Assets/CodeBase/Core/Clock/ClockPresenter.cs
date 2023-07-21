using System;
using CodeBase.Core.Clock.View;

namespace CodeBase.Core.Clock
{
    public class ClockPresenter
    {
        private readonly IClockView[] _views;
        private readonly ClockModel _model;

        public ClockPresenter(ClockModel model, params IClockView[] views)
        {
            _views = views;
            _model = model;
        }

        public void UpdateModel(float deltaTime)
        {
            _model.Update(TimeSpan.FromSeconds(deltaTime));
        }

        public void UpdateViews()
        {
            foreach (var view in _views)
                view.ShowTime(_model.GetCurrentTime());
        }
    }
}