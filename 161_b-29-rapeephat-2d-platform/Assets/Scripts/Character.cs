using UnityEngine;



public abstract class Character : MonoBehaviour
{
    private int health;
    public int Health
    {
        get { return health; }
        set { health = (value < 0) ? 0 : value; }
    }
    //Connect with HealthBar Object
    public HealthBar healthBar;
    
    //use for movement or do some animation stuff
    protected Animator anim;
    protected Rigidbody2D rb;

    public void Innitialize (int startHealth)
    {
        health = startHealth;
        Debug.Log($"({this.name} health is {this.Health}.");
        
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (healthBar != null)
            healthBar.SetMaxHealth(health);
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took damage {damage}! Current health is {Health}");
        //Update current HealthBar when took damage
        if (healthBar != null)
            healthBar.SetHealth(Health);
      
        IsDead();
    }

    public bool IsDead()
    {
        if( Health <= 0 )
            {
            Destroy(this.gameObject);
            return true;
            }
        else { return false; }
    }   
    
    void Start()
    {
        
    }
}
