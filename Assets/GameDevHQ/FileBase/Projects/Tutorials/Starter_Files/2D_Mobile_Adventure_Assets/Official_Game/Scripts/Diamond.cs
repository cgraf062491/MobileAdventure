using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int diamondValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Player playerScript = other.GetComponent<Player>();
            if(playerScript != null)
            {
                playerScript.AddGems(diamondValue);
                Destroy(this.gameObject);
            }
        }
    }
}
