using System;
using CodeBase.Core.Clock.View;
using UnityEngine;

namespace CodeBase.Core.Clock
{
    [Serializable]
    public class ClockSceneData
    {
        [SerializeField] private WallClockView _wallClockView;
        [SerializeField] private DigitalClockView _digitalClockView;

        public WallClockView WallClockView => _wallClockView;

        public DigitalClockView DigitalClockView => _digitalClockView;
    }
}