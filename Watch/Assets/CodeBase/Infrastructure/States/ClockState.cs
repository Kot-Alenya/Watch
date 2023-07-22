using CodeBase.Core.Alarm;
using CodeBase.Core.Clock;
using CodeBase.Infrastructure.Services.Loop;
using CodeBase.Infrastructure.Services.StateMachine;

namespace CodeBase.Infrastructure.States
{
    public class ClockState : IState
    {
        private readonly ClockPresenter _clockPresenter;
        private readonly AlarmPresenter _alarmPresenter;
        private readonly IProjectLoop _loop;

        public ClockState(ClockPresenter clockPresenter, AlarmPresenter alarmPresenter, IProjectLoop loop)
        {
            _clockPresenter = clockPresenter;
            _alarmPresenter = alarmPresenter;
            _loop = loop;
        }

        public void Enter()
        {
            _loop.OnFixedUpdate += UpdateModels;
            _loop.OnUpdate += UpdateViews;
            
            _clockPresenter.Initialize();
        }

        public void Exit()
        {
            _loop.OnFixedUpdate -= UpdateModels;
            _loop.OnUpdate -= UpdateViews;
        }

        private void UpdateModels()
        {
            _clockPresenter.UpdateModel(_loop.FixedDeltaTime);
            _alarmPresenter.UpdateModel();
        }

        private void UpdateViews()
        {
            _clockPresenter.UpdateDigitalClockView();
            _clockPresenter.UpdateWallClockView();
        }
    }
}