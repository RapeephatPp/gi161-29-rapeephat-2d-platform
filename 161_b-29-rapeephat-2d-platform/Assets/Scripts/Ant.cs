using System;
using UnityEngine;

public class Ant : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    [SerializeField] Vector2 velocity;
    public Transform[] MovePoint;

    void Start()
    {
        base.Innitialize(20);

        DamageHit = 20;
        velocity = new Vector2(-1.0f, 0.0f);
        
        
    }
    public override void Behavier()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Behavier();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
