using UnityEngine;

public class CucarShooter : Enemy
{
    public float searchRadius_max = 50f;
    public float searchRadius_min = 10f;
    GameObject point;
    int ShootMode = 0;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        health = 20;
        animator = GetComponent<Animator>();
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShootMode == 0)
        {
            FindPoint();
        }
        else if (ShootMode == 1) {
            if (!point.GetComponent<ShootPoint>().CheckShoot())
            {
                point.GetComponent<ShootPoint>().busy = false;
                ShootMode = 0;
                return;
            }
            if (Vector3.Distance(point.transform.position, gameObject.transform.position) < 4)
            {
                ShootMode = 2;
                animator.SetTrigger("standup");
            }
        else if (ShootMode == 2)
            {
                if (!point.GetComponent<ShootPoint>().CheckShoot())
                {
                    point.GetComponent<ShootPoint>().busy = false;
                    ShootMode = 0;
                    animator.SetTrigger("standown");
                    return;
                }
            }
        }
    }

    void FindPoint()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("CPoint");
        GameObject nearestObject = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject obj in objectsWithTag)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            float distanceToPlayer = Vector3.Distance(player.transform.position, obj.transform.position);
            if (distance < nearestDistance && distanceToPlayer <= searchRadius_max && searchRadius_min <= distanceToPlayer  && obj.GetComponent<ShootPoint>().CheckShoot() && !obj.GetComponent<ShootPoint>().busy)
            {
                nearestDistance = distance;
                nearestObject = obj;
                ShootMode = 1;
            }
        }
        
        if (nearestObject != null) { 
            agent.destination = nearestObject.transform.position;
            point = nearestObject;
            nearestObject.GetComponent<ShootPoint>().busy = true;
        }
    }
}
