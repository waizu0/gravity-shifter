using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControler : MonoBehaviour
{
    Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            _anim.Play("ShotTarget", -1, 0f);
            collision.gameObject.SetActive(false);

        }
    }
}
