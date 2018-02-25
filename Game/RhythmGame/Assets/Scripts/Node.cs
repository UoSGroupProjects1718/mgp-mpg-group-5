using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    public int Dir = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start () {
    rb.velocity = new Vector2(0, -speed);
	}
	
	void Update () {
        SetDirection();
	}

    void SetDirection()
    {
        if (Dir == 1)
        {
            rb.velocity = new Vector2(0, -speed);
        }
        else if (Dir == 2)
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }
}
