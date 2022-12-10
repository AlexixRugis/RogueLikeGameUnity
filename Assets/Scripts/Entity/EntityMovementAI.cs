using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using ARTEX.Rogue.Animations;

namespace ARTEX.Rogue.Entities
{
    [RequireComponent(typeof(AIPath))]
    public class EntityMovementAI : MonoBehaviour
    {
        private AIPath ai;
        private EntityAnimator entityAnimator;
        [SerializeField] private Transform graphics;
        [SerializeField] private LayerMask wayPointCheckMask;
        public bool IsPositionReached => ai.reachedEndOfPath;
        public float Speed {
            get 
            {
                return ai.maxSpeed;
            }
            set
            {
                ai.maxSpeed = value;
            }
        }

        public bool IsStopped
        {
            get
            {
                return ai.isStopped;
            }
            set
            {
                ai.isStopped = value;
            }
        }

        public bool IsPositionReachable(Vector3 position)
        {
            return !Physics2D.OverlapCircle(position, ai.endReachedDistance, wayPointCheckMask);
        }

        public void SetDestination(Vector3 targetPoint)
        {
            IsStopped = false;
            ai.destination = targetPoint;
        }

        private void Awake()
        {
            ai = GetComponent<AIPath>();
            entityAnimator = GetComponent<EntityAnimator>();
        }

        private void Update()
        {
            if (!IsPositionReached) 
            {
                Vector3 velocity = ai.velocity;
                entityAnimator?.SetSpeed(velocity.magnitude);

                if (velocity.x > 0)
                {
                    graphics.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                }
                else if (velocity.x < 0)
                {
                    graphics.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }
            }
            else
            {
                entityAnimator?.SetSpeed(0);
            }
        }
    }
}