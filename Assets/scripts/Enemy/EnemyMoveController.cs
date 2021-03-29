using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private float xVelocity;
    private Transform trans_obj;

    private void Start()
    {
        GetRefernces();
    }
    private void GetRefernces()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        trans_obj = GetComponent<Transform>();
    }
    public void Move(float speed)
    {
        trans_obj.Translate(-Time.deltaTime * speed, 0, 0);
    }
}
