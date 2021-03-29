using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : DamagebleObject
{
    public float speed;

    public float begin_x, end_x;

    private bool flip;
    private EnemyMoveController moveController;
    private Transform trans_obj;
    private Vector3 rotation = new Vector3(0, 180, 0);

    private void Start()
    {
        GetReferences();
    }
    private void GetReferences()
    {
        moveController = GetComponent<EnemyMoveController>();
        trans_obj = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Move();
        if(transform.position.x > end_x)
        {
            flip = false;
        }
        if (transform.position.x < begin_x)
        {
            flip = true;
        }
        Flip();
    }

    private void Flip()
    {
        if (flip)
        {
            trans_obj.rotation = Quaternion.Euler(rotation);
        }
        else
        {
            trans_obj.rotation = Quaternion.Euler(Vector3.zero);
        }
    }

    private void Move()
    {
        moveController.Move(speed);
    }
    
    
}
