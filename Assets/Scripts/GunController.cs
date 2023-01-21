using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public GameObject pistol; //the sprite of pistol

    private PlayerController playerController; // adicionado essa linha

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>(); // adicionado essa linha
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
            pistol.gameObject.SetActive(true);
            Invoke("DisablePistol", .5f);
        }
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        if (playerController.facingRight) // adicionado essa linha
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -bulletSpeed;
        }
    }

    void DisablePistol()
    {
        pistol.SetActive(false);
    }

}