using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARTEX.Rogue.Player;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Player player;

    public Player Player => player;

    public static PlayerManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null) throw new System.Exception($"{GetType()}: Singleton error! Dublicate detected.");
        Instance = this;
    }
}
