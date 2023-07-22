using CodeBase.Core.Alarm;
using CodeBase.Core.Clock;
using CodeBase.Infrastructure.Services.Loop;
using CodeBase.Infrastructure.Services.Network;
using CodeBase.Infrastructure.Services.StateMachine;
using CodeBase.Infrastructure.Services.StateMachine.Implementations;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Logger = CodeBase.Infrastructure.Services.Log.Logger;

namespace CodeBase.Infrastructure
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private ClockStaticData _clockStaticData;
        [SerializeField] private ClockSceneData _clockSceneData;
        [SerializeField] private AlarmSceneData _alarmSceneData;
        [SerializeField] private ProjectLoop _projectLoop;

        private ClockPresenter _clockPresenter;
        private AlarmPresenter _alarmPresenter;
        private IStateMachine _stateMachine;

        private void Awake()
        {
            var logger = new Logger();
            var clockModel = new ClockModel(_clockStaticData, new NetworkTime());
            var alarmModel = new AlarmModel(logger);

            _clockPresenter = new ClockPresenter(clockModel, _clockSceneData);
            _alarmPresenter = new AlarmPresenter(_clockPresenter, _alarmSceneData, alarmModel);
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            _alarmSceneData.AlarmToggle.Initialize(_stateMachine);

            InitializeStateMachine();
            _stateMachine.SwitchTo<ClockState>();
        }

        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(
                new ClockState(_clockPresenter, _alarmPresenter, _projectLoop),
                new AlarmState(_alarmPresenter, _projectLoop));
        }
    }
}