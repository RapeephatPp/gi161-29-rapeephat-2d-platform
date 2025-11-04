using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    public void SetMaxHealth(int maxHealth)
    {   
        //Set Full Value for slider
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {   
        //adapt with the real hp value
        Debug.Log($"Updating healthbar {health}");
        slider.value = health;
    }

}