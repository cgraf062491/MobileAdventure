using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    [SerializeField] private GameObject _acid;
    private bool fire = false;

    public void Fire()
    {
        //Tell Spider to fire
        //Debug.Log("Spider should fire");
        if(fire == true)
        {
            Instantiate(_acid, transform.position, Quaternion.identity);
        }

        fire = !fire;
        
    }
}
