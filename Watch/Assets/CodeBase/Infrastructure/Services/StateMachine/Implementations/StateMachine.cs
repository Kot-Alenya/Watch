using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.Services.StateMachine.Implementations
{
    public class StateMachine : IStateMachine
    {
        private Dictionary<Type, IStateBase> _states;
        private IStateBase _currentState;

        public void Initialize(params IStateBase[] states)
        {
            _states = new(states.Length);

            foreach (var state in states)
                _states.Add(state.GetType(), state);
        }

        public void SwitchTo<StateType>()
            where StateType : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(StateType)];
            (_currentState as IState)?.Enter();
        }
    }
}