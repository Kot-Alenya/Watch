namespace CodeBase.Core.Alarm.View
{
    public interface IAlarmView
    {
        public void Initialize(AlarmPresenter presenter);

        public void Dispose();
    }
}