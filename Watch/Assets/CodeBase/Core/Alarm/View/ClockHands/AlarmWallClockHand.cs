using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Core.Alarm.View.ClockHands
{
    public abstract class AlarmWallClockHand : MonoBehaviour, IAlarmView, IDragHandler, IPointerDownHandler,
        IPointerUpHandler
    {
        [SerializeField] private RectTransform _background;
        private protected AlarmPresenter AlarmPresenter;
        private float _previousAngle;
        private bool _isInitialized;

        public void Initialize(AlarmPresenter presenter)
        {
            AlarmPresenter = presenter;
            _isInitialized = true;
        }

        public void Dispose() => _isInitialized = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isInitialized)
                return;

            if (TryGetPoint(eventData, out var point))
                GetPointAngleDelta(point);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isInitialized)
                return;

            if (TryGetPoint(eventData, out var point))
                AlarmPresenter.SetClockTime(CalculateTime(GetPointAngleDelta(point)));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_isInitialized)
                return;
            
            AlarmPresenter.SetAlarm();
        }

        private protected abstract TimeSpan CalculateTime(float angleDelta);

        private bool TryGetPoint(PointerEventData eventData, out Vector2 point) =>
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _background, eventData.position, eventData.pressEventCamera, out point);

        private float GetPointAngleDelta(Vector2 point)
        {
            var normalizedPoint = (point / _background.sizeDelta * 2).normalized;
            var angle = Quaternion.FromToRotation(normalizedPoint, Vector3.up).eulerAngles.z;
            var delta = angle - _previousAngle;

            if (Mathf.Abs(delta) > 300) //avoiding jump 360 <-> 0
                delta = 0;

            _previousAngle = angle;

            return delta;
        }
    }
}