using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Player player;
    public int health;
    public Animator animator;

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
