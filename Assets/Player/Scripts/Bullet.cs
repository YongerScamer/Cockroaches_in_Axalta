using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 2f;
    public int damage = 20;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}