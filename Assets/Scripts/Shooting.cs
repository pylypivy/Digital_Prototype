using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public Rigidbody bulletPrefab;
    public float bulletSpeed = 10;
    public KeyCode shootKey = KeyCode.Mouse0;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
