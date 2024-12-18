using UnityEngine;

public class CucarShooter : Enemy
{
    public float searchRadius_max = 50f;
    public float searchRadius_min = 10f;
    GameObject point;
    public int ShootMode = 0;
    public Collider coll1, coll2;
    public float shoot_rate = 100;
    public float shoot_time = 0;
    public Acid acid;
    public GameObject spawnAcid;
    public float distance = 0;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot_time > 0)
        {
            shoot_time -= Time.deltaTime;
        }
        if (ShootMode == 0)
        {
            FindPoint();
        }
        else if (ShootMode == 1)
        {
            distance = Vector3.Distance(point.transform.position, gameObject.transform.position);
            if (!point.GetComponent<ShootPoint>().CheckShoot())
            {
                point.GetComponent<ShootPoint>().busy = false;
                ShootMode = 0;
                agent.isStopped = false;
                agent.speed = 12;
                return;
            }
            if (Vector3.Distance(point.transform.position, gameObject.transform.position) < 2)
            {
                ShootMode = 2;
                animator.SetTrigger("standup");
                coll1.enabled = false;
                coll2.enabled = true;
                agent.isStopped = true;
            }
        }
        else if (ShootMode == 2)
        {
            if (!point.GetComponent<ShootPoint>().CheckShoot())
            {
                point.GetComponent<ShootPoint>().busy = false;
                ShootMode = 0;
                animator.SetTrigger("standown");
                coll1.enabled = true;
                coll2.enabled = false;
                agent.isStopped = false;
                agent.speed = 12;
                return;
            }
            Transform target = point.GetComponent<ShootPoint>().wall.transform;
            Vector3 direction = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 6);

            if (AreVectorsAligned(direction, transform.forward))
            {
                ShootMode = 3;
                agent.speed = 0;
            }
        }
        else if (ShootMode == 3)
        {
            if (!point.GetComponent<ShootPoint>().CheckShoot())
            {
                point.GetComponent<ShootPoint>().busy = false;
                ShootMode = 0;
                animator.SetTrigger("standown");
                coll1.enabled = true;
                coll2.enabled = false;
                agent.isStopped = false;
                agent.speed = 12;
                return;
            }
            if (shoot_time <= 0)
            {
                shoot_time = shoot_rate;
                Instantiate(acid, spawnAcid.transform.position, spawnAcid.transform.rotation);
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
    public bool AreVectorsAligned(Vector3 A, Vector3 B)
    {
        Vector3 normalizedA = A.normalized;
        Vector3 normalizedB = B.normalized;
        float dotProduct = Vector3.Dot(normalizedA, normalizedB);
        const float epsilon = 0.1f; // Порог для погрешности
        return dotProduct > 1 - epsilon;
    }
}
