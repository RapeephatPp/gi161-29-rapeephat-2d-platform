using UnityEngine;

public class Crocodile : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Behavier()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        base.Innitialize(50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
