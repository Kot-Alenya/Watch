using CodeBase.Core.Clock;
using CodeBase.Core.Clock.View;
using CodeBase.Infrastructure.Services.Network;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private WallClockUIView _wallClockView;
        [SerializeField] private DigitalClockUIView _digitalClockUIView;
        [SerializeField] private ClockStaticData _clockStaticData;

        private ClockPresenter _clockPresenter;

        private void Start()
        {
            var networkTime = new NetworkTime();
            var clockModel = new ClockModel(_clockStaticData, networkTime);

            _clockPresenter = new ClockPresenter(clockModel, _wallClockView, _digitalClockUIView);

            networkTime.Initialize(_clockStaticData.NtpServers);
            clockModel.Initialize();
        }

        private void FixedUpdate()
        {
            _clockPresenter.UpdateModel(Time.fixedDeltaTime);
            _clockPresenter.UpdateViews();
        }
    }
}