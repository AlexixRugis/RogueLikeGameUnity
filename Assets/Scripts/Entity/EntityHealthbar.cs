using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARTEX.Rogue.Entities
{
    public class EntityHealthbar : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Entity entity;

        private void Awake()
        {
            if (entity == null) entity = GetComponentInParent<Entity>();
        }

        private void Start()
        {   
            entity.Stats.OnHealthChangedEvent += UpdateHealth;
        }

        private void OnDisable()
        {
            entity.Stats.OnHealthChangedEvent -= UpdateHealth;
        }

        private void UpdateHealth(int newValue, int maxValue)
        {
            image.fillAmount = (float)newValue / maxValue;
        }
    }
}