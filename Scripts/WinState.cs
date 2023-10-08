using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.hasKeyToCastle)
            {
                UIManager.Instance.ActivateWinMenu();
                Destroy(this.gameObject);
            }
        }
    }
}
