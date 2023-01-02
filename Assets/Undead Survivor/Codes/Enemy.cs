using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(!isLive)
        {
            return;
        }

        Vector2 dirVec = target.position - rigid.position; // monster -> target direction
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; 
        rigid.MovePosition(rigid.position + nextVec); // monster move
        rigid.velocity = Vector2.zero; // monster crash speed
    }

    private void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x; // monster flip
    }
}
