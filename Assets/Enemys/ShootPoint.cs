using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    public Transform player; // ������ �� ������ ������
    public float rayDistance = 10f; // ��������� �����
    public LayerMask wallLayer; // ���� ����
    public float height = 10;
    public bool busy = false;
    public GameObject wall;

    private void Start()
    {
        wall = transform.parent.gameObject;
    }

    void Update()
    {
        if (CheckForWall())
        {
            Debug.Log("Wall");
        }
        if (CheckForPlayer())
        {
            Debug.Log("Player");
        }
    }

    bool CheckForWall()
    {
        // ������� ���, ������������ � ������
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // ��������� Raycast ��� ������ �����
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToPlayer, out hit, Vector3.Distance(player.position, transform.position), wallLayer))
        {
            return true;
        }
        return false;
    }
    
    bool CheckForPlayer()
    {
        // ������� ���, ������������ � ������, �� � ����������� ����������� Y
        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        Vector3 directionToPlayer = (player.position - startPosition).normalized;

        // ��������� Raycast ��� ������ ������
        RaycastHit hit;
        if (Physics.Raycast(startPosition, directionToPlayer, out hit, rayDistance))
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
        Gizmos.DrawLine(transform.position, transform.position + (player.position - transform.position).normalized * rayDistance);

        Gizmos.color = Color.green;
        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        Gizmos.DrawLine(startPosition, startPosition + (player.position - startPosition).normalized * rayDistance);
    }
}