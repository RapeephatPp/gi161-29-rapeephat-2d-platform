using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public IShootable Shooter;
    public abstract void Move();
    public abstract void OnHitWith(Character character);
    
    public void InitWeapon(int newDamage, IShootable newShooter)
    { 
        damage = newDamage;
        Shooter = newShooter;
    }

    public int GetShootDirection()
    {
        if (Shooter == null || Shooter.ShootPoint == null || Shooter.ShootPoint.parent == null)
        {
            Debug.LogError("Shooter or ShootPoint is null");
            return 0; // or handle it in some other way
        }

        float value = Shooter.ShootPoint.position.x - Shooter.ShootPoint.parent.position.x;
        if (value > 0)
        {
            return 1;
        }  // face right 
        else
        {
            return -1;
        } // face left
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            OnHitWith(other.GetComponent<Character>());
            Destroy(this.gameObject, 5f);
        }
    }

}
