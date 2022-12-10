using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.StateMachines
{
    public interface IState
    {
        void Enter(IStateMachine stateMachine);
        void Exit(IStateMachine stateMachine);
        void Tick(IStateMachine stateMachine);
    }
}