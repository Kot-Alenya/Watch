using CodeBase.Infrastructure.Services.StateMachine;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Core.Alarm.View
{
    public class AlarmToggle : MonoBehaviour
    {
        [SerializeField] private Button _selectableButton;
        private IStateMachine _stateMachine;
        private bool _isAlarmState;

        public void Initialize(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _selectableButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _isAlarmState = !_isAlarmState;

            if (_isAlarmState)
                _stateMachine.SwitchTo<AlarmState>();
            else
                _stateMachine.SwitchTo<ClockState>();
        }
    }
}