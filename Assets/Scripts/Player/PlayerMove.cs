using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if(moveX < 0)
            sprite.flipX = true;
        if(moveX > 0)
            sprite.flipX = false;

        transform.Translate(moveX * moveSpeed * Time.deltaTime, moveY * moveSpeed * Time.deltaTime, 0);

    }
}
