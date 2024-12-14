using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LevelSpawner prev;
    public LevelSpawner next;
    public LevelSpawner level;
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
            nextOn = true;
            next = Instantiate(level);
            next.transform.position = connect_out.transform.position + (level.transform.position - level.connect_in.transform.position);
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
