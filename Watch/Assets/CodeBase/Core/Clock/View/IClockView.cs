using System;

namespace CodeBase.Core.Clock.View
{
    public interface IClockView
    {
        public void ShowTime(TimeSpan time);
    }
}