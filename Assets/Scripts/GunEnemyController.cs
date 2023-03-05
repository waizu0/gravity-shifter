using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemyController : MonoBehaviour
{
    public GameObject bloodParticle;
    private Rigidbody2D rb;
    private PlayerController player;
    public GameObject bulletPrefab;
    public float cooldown = 0.5f;
    public int poolSize = 1;
    private List<GameObject> bulletPool;
    private float lastShotTime;
    public Transform bulletOriginPoint;
    public AudioSource _audioSourcePlayer;
    public AudioClip _laserShotClip;
    public GameObject door;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<PlayerController>();


        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    private void Update()
    {
        if (Time.time - lastShotTime > cooldown && door.activeSelf == false)
        {
            _audioSourcePlayer.clip = _laserShotClip;
            _audioSourcePlayer.Play(1);
            lastShotTime = Time.time;
            GameObject bullet = GetBulletFromPool();
            if (bullet != null)
            {
                bullet.transform.position = new Vector3(bulletOriginPoint.transform.position.x, bulletOriginPoint.transform.position.y, bulletOriginPoint.transform.position.z);
                bullet.SetActive(true);
                _audioSourcePlayer.Play(1);
            }
        }
    }

    private GameObject GetBulletFromPool()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }
        return null;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        if (collision.gameObject.CompareTag("Laser"))
        {
           
            Death();
            
        }
    }

    private void Death()
    {
        Instantiate(bloodParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}