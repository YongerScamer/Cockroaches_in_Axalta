using UnityEngine;

public class Acid : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 10f;
    public int damage = 20;
    Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 norm = Vector3.Normalize(player.transform.position - transform.position);
        rb.linearVelocity = norm * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(damage);
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}