using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Update()
    {
        //Stay still
    }

    public override void Movement()
    {
        //Stay still
    }

    public void Damage()
    {
        if(isDead == true)
        {
            return;
        }
        Debug.Log("Spider Damage");
        Health -= 1;

        if(Health <= 0)
        {
            isDead = true;
            GameObject newDiamond = Instantiate(base.diamond, transform.position, Quaternion.identity);
            newDiamond.GetComponent<Diamond>().diamondValue = base.gems;
            anim.SetTrigger("Death");
        }
    }
}
