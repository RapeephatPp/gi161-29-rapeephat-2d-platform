using Unity.Mathematics;
using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    [SerializeField] private float atkRange;
    public Player player; //target to atk
    void Start()
    {
        base.Innitialize(50);
        DamageHit = 30;
        //set atk range and target
        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
        
        //set timer variables for throwing rock
        WaitTime = 0.0f;
        ReloadTime = 5.0f; // throw rock every 5s
    }
 
    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        Behavier();
    }
    public override void Behavier()
    {
        //find distance between Croccodile and Player
        Vector2 distance = transform.position - player.transform.position;
        
        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }
    }

    [field: SerializeField]public GameObject Bullet { get; set; }
    [field: SerializeField]public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    public void Shoot() 
    {
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot"); //call Shoot anim
            var bullet = Instantiate(Bullet, ShootPoint.position, quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            rock.InitWeapon(30, this);
            WaitTime = 0;
        }
    }
}
