using UnityEngine;


public class Cucar : Enemy
{
    public float bite_rate = 100;
    public float bite_time = 0;
    public int damage = 10;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        health = 20;
        animator = GetComponent<Animator>();
        agent.destination = player.transform.position;
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        if(bite_time > 0)
        {
            bite_time -= Time.deltaTime;
        }
        agent.destination = player.transform.position;
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 4)
        {
            Attack();
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }

    void Attack()
    {
        if (bite_time <= 0)
        {
            player.Damage(damage);
            bite_time = bite_rate;
        }
    }

}
