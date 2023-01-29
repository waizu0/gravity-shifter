using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float cooldown = 0.5f;
    public int poolSize = 1;
    private List<GameObject> bulletPool;
    private float lastShotTime;
    public Transform bulletOriginPoint;
    public GameObject pistol;
    public AudioSource _audioSourcePlayer;
    public AudioClip _laserShotClip;
        

    void Start()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastShotTime > cooldown)
            {
                _audioSourcePlayer.clip = _laserShotClip;
                _audioSourcePlayer.Play(1);
                pistol.gameObject.SetActive(true);
                Invoke("DisablePistol", .5f);
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
    }

    void DisablePistol()
    {
        pistol.gameObject.SetActive(false);
    }

    private GameObject GetBulletFromPool()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if(!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }
        return null;
    }

    private void OnDisable()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            bulletPool[i].SetActive(false);
        }
    }

}
