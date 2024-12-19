using UnityEngine;

public class Player : MonoBehaviour
{
    public int max_health = 100;
    public int health;
    public Health_Bar healthBar;
    void Start()
    {
        health = max_health;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Damage(1);
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health < 0)
        {
            Debug.Log("Смерт");
        }
    }
}
