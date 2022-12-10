using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARTEX.Rogue.Popups
{
    public static class PopupManager
    {
        private const string POPUP_PREFAB = "Prefabs/Popup";
        private static Popup prefab;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            prefab = Resources.Load<Popup>(POPUP_PREFAB);
        }

        public static void MakePopup(Vector3 position, string text, Color color)
        {
            Popup popup = GameObject.Instantiate(prefab, position, Quaternion.identity);
            popup.SetText(text, color);
        }

        public static void MakePopupInArea(Vector3 position, float distance, string text, Color color)
        {
            Vector3 offset = new Vector3(Random.Range(-distance, distance), Random.Range(-distance, distance), 0);
            MakePopup(position + offset, text, color);
        }
    }
}