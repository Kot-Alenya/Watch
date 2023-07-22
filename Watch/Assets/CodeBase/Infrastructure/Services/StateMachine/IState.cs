namespace CodeBase.Infrastructure.Services.StateMachine
{
    public interface IState : IStateBase
    {
        public void Enter();
    }
}