using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character, IShootable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Innitialize(100); // set player HP
        ReloadTime = 1.0f;
        WaitTime = 0.0f;
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWith(enemy);
            Debug.Log($"{this.name} collides with {enemy.name}!");
        }
    }
    // Update is called once per frame
    private void Update()
    {
        Shoot();
    }

    private void FixedUpdate() //loop every 0.02 sec
    {
        WaitTime += Time.fixedDeltaTime; 
    }

    [field: SerializeField]public GameObject Bullet { get; set; }
    [field: SerializeField]public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
            {
                banana.InitWeapon(20, this);

                WaitTime = 0.0f; // reset wait time
            }
        }
    }
}
