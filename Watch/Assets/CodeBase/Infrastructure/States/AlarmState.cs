using CodeBase.Core.Alarm;
using CodeBase.Core.Clock;
using CodeBase.Infrastructure.Services.Loop;
using CodeBase.Infrastructure.Services.StateMachine;

namespace CodeBase.Infrastructure.States
{
    public class AlarmState : IState
    {
        private readonly AlarmPresenter _alarmPresenter;
        private readonly IProjectLoop _loop;

        public AlarmState(AlarmPresenter alarmPresenter, IProjectLoop loop)
        {
            _alarmPresenter = alarmPresenter;
            _loop = loop;
        }

        public void Enter()
        {
            _alarmPresenter.Initialize();

            _loop.OnUpdate += _alarmPresenter.UpdateViews;
        }

        public void Exit()
        {
            _alarmPresenter.Dispose();

            _loop.OnUpdate -= _alarmPresenter.UpdateViews;
        }
    }
}