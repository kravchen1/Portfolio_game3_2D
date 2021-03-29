using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject player_body;
    [SerializeField]
    private int xVelocity = 5;
    [SerializeField]
    private int yVelocity = 1;

    public LayerMask GroundLayerMask;
    public float RayDistance;


    private Transform Trans_player_body;
    private Transform Trans_player;
    private Animator _animator;

    private Rigidbody2D rb;
    private Vector3 rotation = new Vector3(0, 180, 0);
    private RaycastHit2D _raycast;
    
    private bool isDie;
    private bool flip;
    private bool isGround;

    private float moveInput, jumpInput;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Trans_player_body = player_body.GetComponent<Transform>();
        Trans_player = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Animate();
        StateUpdate();
        Move();
        Flip();
        Jump();

    }

    private void Move()
    {
        moveInput = Input.GetAxis("Horizontal");

        //Движение
        if (!isDie)
        {
            if (moveInput < 0)
            {
                Trans_player.Translate(-Time.deltaTime * xVelocity, 0, 0);
                flip = false;
            }
            else if (moveInput > 0)
            {
                Trans_player.Translate(Time.deltaTime * xVelocity, 0, 0);
                flip = true;
            }
        }
    }
    private void Jump()
    {
        jumpInput = Input.GetAxis("Jump");

        //Прыжок
        if (jumpInput > 0 && isGround)
        {
            rb.AddForce(Vector2.up * yVelocity, ForceMode2D.Impulse);
        }


    }
    private void StateUpdate()
    {
        _raycast = Physics2D.Raycast(Trans_player.position,Vector2.down,RayDistance,GroundLayerMask);
        isGround = _raycast;
    }
    private void Flip()
    {
        if(flip)
        {
            Trans_player_body.rotation = Quaternion.Euler(rotation);
        }
        else
        {
            Trans_player_body.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
    private void Animate()
    {
        _animator.SetBool("isRun", moveInput != 0);
        _animator.SetBool("isJump", !isGround);

    }
    
}
