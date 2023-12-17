using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Animations;

namespace ARTEX.Rogue.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EntityMovementRigidbody : MonoBehaviour
    {
        [SerializeField] private Transform graphics;

        private EntityAnimator entityAnimator;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            entityAnimator = GetComponent<EntityAnimator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector3 direction, float speed)
        {
            Vector3 movement = direction.normalized * speed * Time.deltaTime;

            if(movement.x > 0)
            {
                graphics.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if(movement.x < 0)
            {
                graphics.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }

            _rigidbody.MovePosition(transform.position + movement);
            entityAnimator?.SetSpeed(movement.magnitude);
        }

        protected void Die()
        {
            entityAnimator?.PlayDie();
        }
    }
}