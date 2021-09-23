using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canAttack = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit: " + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null && _canAttack == true)
        {
            hit.Damage();
            _canAttack = false;
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        //Debug.Log("Cooldown complete");
        _canAttack = true;
    }
}
