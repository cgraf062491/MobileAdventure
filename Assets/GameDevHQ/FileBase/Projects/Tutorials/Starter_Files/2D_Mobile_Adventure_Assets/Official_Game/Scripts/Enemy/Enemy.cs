using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int gems;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject diamond;
    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected SpriteRenderer sprite;
    protected Animator anim;
    protected GameObject player;

    protected bool isHit = false;
    protected bool isDead = false;
    protected float playerDist = 5.0f;

    public void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    public virtual void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        
        if(isDead == false)
        {
            Movement();
        }
    }

    public virtual void Movement()
    {
        if(currentTarget == pointB.position)
        {
            sprite.flipX = false;
        }
        else if(currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }

        if(transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if(transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        playerDist = Vector3.Distance(player.transform.localPosition, transform.localPosition);
        Vector3 direction = player.transform.localPosition - transform.position;

        if(anim.GetBool("InCombat") == true)
        {
            if(direction.x >= 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
        

        if(playerDist >= 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
    }    
}
