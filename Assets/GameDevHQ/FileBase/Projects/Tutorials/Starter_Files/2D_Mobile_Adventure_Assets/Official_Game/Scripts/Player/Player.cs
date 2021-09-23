using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
	[SerializeField] private float _speed = 3.0f;
	[SerializeField] private float _jumpForce = 3.0f;
	private Rigidbody2D _rb;
    private PlayerAnimation _playAnim;
    private SpriteRenderer _sprite;
    private SpriteRenderer _swordArcSprite;

    private bool _jumpTime = false;
    public int gems;

    public int Health { get; set; }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playAnim = GetComponent<PlayerAnimation>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(Input.GetMouseButtonDown(0) && IsGrounded())
        {
           _playAnim.Attack();
        }
    }

    void Movement()
    {
        if(_jumpTime == false)
        {
            IsGrounded();
        }
        float x_input = Input.GetAxisRaw("Horizontal");
        Flip(x_input);
        _playAnim.Move(x_input);
        _rb.velocity = new Vector2(x_input * _speed, _rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _playAnim.Jump(true);
            StartCoroutine(JumpingTime());
        }
    }

    bool IsGrounded()
    {
    	RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 6);
        //Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if(hit.collider != null)
        {
            _playAnim.Jump(false);
        	return true;
        }
        else
        {
            return false;
        }   
    }

    public void Damage()
    {
        if(Health <= 0)
        {
            return;
        }
        Debug.Log("Player Damaged");
        Health -= 1;
        if(Health >= 0)
        {
            UIManager.Instance.UpdateLives(Health);
        }

        if(Health == 0)
        {
            _playAnim.Death();
        }
        
    }

    public void AddGems(int gemValue)
    {
        gems += gemValue;
        UIManager.Instance.UpdateGemCount(gems);
    }

    void Flip(float x_input)
    {
        if(x_input < 0.0f)
        {
            _sprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;
            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
        else if(x_input > 0.0f)
        {
            _sprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
    }

    IEnumerator JumpingTime()
    {
        _jumpTime = true;
        yield return new WaitForSeconds(0.5f);
        _jumpTime = false;
    }
}
