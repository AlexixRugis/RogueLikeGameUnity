using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.StateMachines;
using System;

namespace ARTEX.Rogue.Entities
{
    public abstract class StateEntity : Entity, IStateMachine
    {
        public IState CurrentState { get; private set; }

        protected Dictionary<Type, IState> stateMap = new Dictionary<Type, IState>();

        public void ChangeState(IState state)
        {
            if (CurrentState == state) return;
            if (CurrentState != null)
            {
                CurrentState.Exit(this);
            }

            CurrentState = state;

            if (CurrentState != null)
            {
                CurrentState.Enter(this);
            }
        }

        public IState GetState<T>() where T : IState
        {
            var type = typeof(T);
            return stateMap[type];
        }

        private void Update()
        {
            if (CurrentState != null)
                CurrentState.Tick(this);
        }
    }
}