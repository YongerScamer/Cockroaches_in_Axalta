using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    public Player player; // ������ �� ������ ������
    public float rayDistance = 10f; // ��������� �����
    public LayerMask wallLayer;
    public LayerMask playerLayer;// ���� ����
    public float height = 10;
    public bool busy = false;
    public GameObject wall;

    void Start()
    {
        wall = transform.parent.gameObject;
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {

    }

    bool CheckForWall()
    {
        // ������� ���, ������������ � ������
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        // ��������� Raycast ��� ������ �����
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToPlayer, out hit, Vector3.Distance(player.transform.position, transform.position), wallLayer))
        {
            return true;
        }
        return false;
    }
    
    bool CheckForPlayer()
    {
        // ������� ���, ������������ � ������, �� � ����������� ����������� Y
        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        Vector3 vector3 = Vector3.Normalize(player.transform.position - startPosition);
        Vector3 directionToPlayer = vector3;

        // ��������� Raycast ��� ������ ������
        RaycastHit hit;
        if (Physics.Raycast(startPosition, directionToPlayer, out hit, rayDistance, playerLayer))
        {
            if (hit.collider.CompareTag("Player")) // ���������, ��� � ������ ������ ���������� ��� "Player"
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckShoot()
    {
        return CheckForPlayer() && CheckForWall();
    }
    private void OnDrawGizmos()
    {
        // ���������� ���� � ��������� ��� ������������
        Gizmos.color = Color.red;
//        Gizmos.DrawLine(transform.position, transform.position + (player.position - transform.position).normalized * rayDistance);

        Gizmos.color = Color.green;
        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
//        Gizmos.DrawLine(startPosition, startPosition + (player.position - startPosition).normalized * rayDistance);

        if(CheckShoot())
        {
            Gizmos.color = Color.green;
        }
        else 
        {
            Gizmos.color = Color.blue;
        }

        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 30);
    }
}