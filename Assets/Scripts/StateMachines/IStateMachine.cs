using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.StateMachines
{
    public interface IStateMachine
    {
        IState CurrentState { get; }
        void ChangeState(IState state);
        IState GetState<T>() where T : IState;

    }
}