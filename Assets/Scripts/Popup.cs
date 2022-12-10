using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ARTEX.Rogue.Popups
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private void Start()
        {
            StartCoroutine(LifeCycle());
        }

        private void Update()
        {
            text.color = Color.Lerp(text.color, Color.clear, Time.deltaTime);
        }

        public void SetText(string text, Color color)
        {
            this.text.text = text;
            this.text.color = color;
        }

        private IEnumerator LifeCycle()
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}