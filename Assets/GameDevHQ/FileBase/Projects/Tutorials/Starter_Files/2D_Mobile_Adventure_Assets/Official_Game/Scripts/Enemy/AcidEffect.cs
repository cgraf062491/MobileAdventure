using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private bool _canAttack = true;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5.0f);
    }
    
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(3.0f, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit: " + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null && _canAttack == true)
        {
            hit.Damage();
            _canAttack = false;
            Destroy(this.gameObject);
        }
    }
}
