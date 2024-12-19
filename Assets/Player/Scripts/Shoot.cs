using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    void Update()
    {
        if (Time.timeScale == 0f)
            return;
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
