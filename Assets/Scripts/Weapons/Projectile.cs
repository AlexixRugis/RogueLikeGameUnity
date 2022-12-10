using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ARTEX.Rogue.Weapons
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        private int damage;

        private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private float speed;
        private Vector3 direction;

        private bool isMoving;

        public delegate bool CanTakeDamage(IDamagable damagable);

        private CanTakeDamage damagableChecker;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            isMoving = false;
        }

        public void Initialize(ProjectileInfo info, int damage, Vector3 position, Vector3 direction, CanTakeDamage damagableChecker)
        {
            spriteRenderer.sprite = info.Sprite;
            transform.position = position;
            speed = info.Speed;
            this.direction = direction;
            this.damage = damage;
            this.damagableChecker = damagableChecker;
            isMoving = true;

            transform.right = direction;
        }

        private void Update()
        {
            if (isMoving)
            {
                _rigidbody.MovePosition(transform.position + direction * speed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            IDamagable damagable = collider.transform.GetComponent<IDamagable>();
            if (damagable != null)
            {
                if (damagableChecker.Invoke(damagable))
                {
                    damagable.TakeDamage(damage);
                    StartCoroutine(Die());
                }
            }
            else
            {
                StartCoroutine(Die());
            }
        }

        private IEnumerator Die()
        {
            spriteRenderer.enabled = false;
            isMoving = false;
            ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
            particleSystem?.Play();
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
        }
    }
}