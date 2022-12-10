using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Animations
{
    [RequireComponent(typeof(Animator))]
    public class EntityAnimator : MonoBehaviour
    { 
        private const string DIE_PARAM = "IsDead";
        private const string SPEED_PARAM = "Speed";

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void PlayDie()
        {
            animator.SetTrigger(DIE_PARAM);
        }

        public void SetSpeed(float speed)
        {
            animator.SetFloat(SPEED_PARAM, speed);
        }
    }
}