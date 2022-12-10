using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ARTEX.Rogue.Walls
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private GameObject wall;

        public UnityEvent OnOpened;
        public UnityEvent OnClosed;

        public bool IsOpened { get; private set; }
        private void Start()
        {
            IsOpened = false;
            Open();
        }

        public void Open()
        {
            if (IsOpened) return;
            IsOpened = true;

            wall.SetActive(false);
            OnOpened?.Invoke();
        }

        public void Close()
        {
            if (!IsOpened) return;
            IsOpened = false;

            wall.SetActive(true);
            OnClosed?.Invoke();
        }
    }
}