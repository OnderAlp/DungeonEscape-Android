using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if(_canDamage == true)
            {
                hit.Damage();
                _canDamage = false;
                StartCoroutine(ResetCooldown());
            }
            
        }
    }

    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(0.8f);
        _canDamage = true;
    }
}
