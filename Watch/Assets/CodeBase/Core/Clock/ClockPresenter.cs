using System;

namespace CodeBase.Core.Clock
{
    public class ClockPresenter
    {
        private readonly ClockSceneData _sceneData;
        private readonly ClockModel _model;

        public ClockPresenter(ClockModel model, ClockSceneData sceneData)
        {
            _sceneData = sceneData;
            _model = model;
        }

        public void Initialize() => _model.Initialize();

        public void UpdateModel(float deltaTime) => _model.Update(TimeSpan.FromSeconds(deltaTime));

        public void UpdateDigitalClockView(TimeSpan time) => _sceneData.DigitalClockView.ShowTime(time);

        public void UpdateWallClockView(TimeSpan time) => _sceneData.WallClockView.ShowTime(time);

        public TimeSpan GetCurrentTime() => _model.GetCurrentTime();

        public void SetCurrentTime(TimeSpan time) => _model.SetCurrentTime(time);
    }
}