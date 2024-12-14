using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
