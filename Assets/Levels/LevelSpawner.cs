using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class LevelSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LevelSpawner prev;
    public LevelSpawner next;
    public LevelSpawner[] level;
    public GameObject connect_in;
    public GameObject connect_out;
    bool nextOn;
    void Start()
    {
        nextOn = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextLevel()
    {
        if (!nextOn)
        {
            int n = Random.Range(0, level.Length);
            nextOn = true;
            next = Instantiate(level[n]);
            foreach (NavMeshAgent enemy in next.transform.Find("Enemys").gameObject.GetComponentsInChildren<NavMeshAgent>())
            {
                enemy.enabled = false;
            }
            next.transform.position = connect_out.transform.position + (level[n].transform.position - level[n].connect_in.transform.position);
            foreach (NavMeshAgent enemy in next.transform.Find("Enemys").gameObject.GetComponentsInChildren<NavMeshAgent>())
            {
                enemy.enabled = true;
            }
            next.level = level;
            next.prev = gameObject.GetComponent<LevelSpawner>();
            Destroy(prev);
        }
       
    }
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
