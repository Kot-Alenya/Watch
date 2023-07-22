using CodeBase.Core.Alarm;
using CodeBase.Infrastructure.Services.Loop;
using CodeBase.Infrastructure.Services.StateMachine;

namespace CodeBase.Infrastructure.States
{
    public class AlarmState : IState
    {
        private readonly AlarmPresenter _presenter;
        private readonly IProjectLoop _loop;

        public AlarmState(AlarmPresenter presenter, IProjectLoop loop)
        {
            _presenter = presenter;
            _loop = loop;
        }

        public void Enter()
        {
            _presenter.Initialize();

            _loop.OnUpdate += _presenter.UpdateViews;
        }

        public void Exit()
        {
            _presenter.Dispose();

            _loop.OnUpdate -= _presenter.UpdateViews;
        }
    }
}