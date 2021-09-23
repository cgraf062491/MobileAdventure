using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        if(isDead == true)
        {
            return;
        }
        Debug.Log("Damage Skeleton");
        isHit = true;
        Health -= 1;
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);

        if(Health <= 0)
        {
            isDead = true;
            GameObject newDiamond = Instantiate(base.diamond, transform.position, Quaternion.identity);
            newDiamond.GetComponent<Diamond>().diamondValue = base.gems;
            anim.SetTrigger("Death");
        }
    }
}
