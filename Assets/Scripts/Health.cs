using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private int health;

    public void TakeDamege()
    {
        
        health--;
        print(name + "" + health);
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
