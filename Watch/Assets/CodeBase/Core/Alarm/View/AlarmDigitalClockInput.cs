using TMPro;
using UnityEngine;

namespace CodeBase.Core.Alarm.View
{
    public class AlarmDigitalClockInput : MonoBehaviour, IAlarmView
    {
        [SerializeField] private TMP_InputField _timeInputField;
        private AlarmPresenter _presenter;

        private void Awake() => _timeInputField.interactable = false;

        public void Initialize(AlarmPresenter presenter)
        {
            _timeInputField.onSelect.AddListener(OnSelect);
            _timeInputField.onDeselect.AddListener(OnDeselect);
            _timeInputField.onValueChanged.AddListener(OnValueChanged);

            _presenter = presenter;

            _timeInputField.interactable = true;
        }

        public void Dispose()
        {
            _timeInputField.onSelect.RemoveListener(OnSelect);
            _timeInputField.onDeselect.RemoveListener(OnDeselect);
            _timeInputField.onValueChanged.RemoveListener(OnValueChanged);

            _timeInputField.interactable = false;
        }

        private void OnSelect(string text) => _presenter.SetDigitalClockSelected(true);

        private void OnDeselect(string text)
        {
            _presenter.SetAlarm();
            _presenter.SetDigitalClockSelected(false);
        }

        private void OnValueChanged(string text)
        {
            if (_presenter.TryParseTime(text, out var time))
                _presenter.SetClockTime(time);
        }
    }
}