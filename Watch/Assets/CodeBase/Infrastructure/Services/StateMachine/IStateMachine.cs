namespace CodeBase.Infrastructure.Services.StateMachine
{
    public interface IStateMachine
    {
        public void Initialize(params IStateBase[] states);

        public void SwitchTo<StateType>()
            where StateType : IState;
    }
}