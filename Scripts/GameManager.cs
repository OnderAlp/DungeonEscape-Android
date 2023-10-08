using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("Game Manager is Null!");
            }

            return _instance;
        }
    }
    public bool hasFireSword { get; set; }
    public bool hasDoubleJump { get; set; }
    public bool hasKeyToCastle { get; set; }
    
    public Player Player { get; private set; }
    public Player player { get; private set; }

    private void Awake()
    {
        _instance = this;
        Time.timeScale = 1;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        hasKeyToCastle = false;
        hasFireSword = false;
        hasDoubleJump = false;
        player = Player.GetComponent<Player>();

    }

    public void DoubleJumpActivation()
    {
        hasDoubleJump = true;
    }

}
