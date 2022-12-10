using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Entities;
using Pathfinding;
using ARTEX.Rogue.Weapons;
using UnityEngine.Events;
using ARTEX.Rogue.Animations;

namespace ARTEX.Rogue.Enemies
{
    [RequireComponent(typeof(AIPath), typeof(EntityMovementAI), typeof(EnemyWeapon))]
    public class Enemy : Entity
    {
        [Header("Patrol behaviour")]
        [SerializeField] private float speed;
        [SerializeField] private Vector2 stayTime;
        [SerializeField] private Vector2 movementMagnitude;
        [Header("Anger behaviour")]
        [SerializeField] private float speedOnAnger;
        [SerializeField] private Vector2 angerStayTime;
        [SerializeField] private Vector2 angerMovementMagnitude;
        [SerializeField] private float movementAngle;
        [Space]
        [SerializeField] private LayerMask testPlayerMask;
        private EntityMovementAI ai;
        private EnemyWeapon weapon;
        private Transform player;


        private bool isPlayerVisible = false;

        private float stayTimer = 0;

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public float SpeedOnAnger
        {
            get { return speedOnAnger; }
            set { speedOnAnger = value; }
        }

        public float AngerStayTime
        {
            set { angerStayTime = Vector2.one * value; }
        }

        protected override void Die()
        {
            base.Die();
            Destroy(gameObject);
        }

        protected override void Awake()
        {
            base.Awake();
            ai = GetComponent<EntityMovementAI>();
            weapon = GetComponent<EnemyWeapon>();
        }

        private void Start()
        {
            player = PlayerManager.Instance.Player.transform;

            ai.SetDestination(transform.position);
            StartCoroutine(TestPlayerRoutine());
        }

        private void Update()
        {
            HandleMovement();
            HandleAttack();
        }

        private void HandleMovement()
        {
            ai.Speed = GetMovementSpeed();
            if (ai.IsPositionReached)
            {
                if (stayTimer > 0)
                {
                    stayTimer -= Time.deltaTime;
                    return;
                }

                Vector3 nextPos;
                if (GetNextWaypoint(out nextPos))
                {
                    ai.SetDestination(nextPos);
                    stayTimer = GetStayTime();
                }
            }
        }

        private void HandleAttack()
        {
            if(isPlayerVisible)
            {
                weapon.IsTargeting = true;
                weapon.Shoot();
            }
            else
            {
                weapon.IsTargeting = false;
            }
        }

        private float GetStayTime()
        {
            return isPlayerVisible ? Random.Range(angerStayTime.x, angerStayTime.y) : Random.Range(stayTime.x, stayTime.y);
        }

        private float GetMovementSpeed()
        {
            return isPlayerVisible ? speedOnAnger : speed;
        }

        private IEnumerator TestPlayerRoutine()
        {
            while (true)
            {
                isPlayerVisible = TestPlayerVisible();
                yield return new WaitForSeconds(0.2f);
            }
        }

        private bool TestPlayerVisible()
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, player.position, testPlayerMask);
            Debug.DrawLine(transform.position, player.position, Color.red, 0.1f);
            return hit.transform == player;
        }

        private bool GetNextWaypoint(out Vector3 position)
        {
            float angle;
            float magnitude;
            if(isPlayerVisible)
            {
                Vector3 direction = player.position - transform.position;
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + Random.Range(-movementAngle, movementAngle);
                magnitude = Random.Range(angerMovementMagnitude.x, angerMovementMagnitude.y);
            }
            else
            {
                angle = Random.Range(0, 360);
                magnitude = Random.Range(movementMagnitude.x, movementMagnitude.y);
            }

            Vector3 movement = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * magnitude;

            position = ai.transform.position + movement;
            Debug.DrawLine(position, position + Vector3.up, Color.red, 1f);
            return ai.IsPositionReachable(position);
        }
    }
}