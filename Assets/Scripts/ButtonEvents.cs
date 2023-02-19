using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public bool _openDoorEvent, shootButtonEvent;
    public bool _pressing;
    public Animator _doorAnimator;

    public Sprite _normalStateButton, _pressingStateButton;
    SpriteRenderer _renderer;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (_openDoorEvent)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Prop")
            {
                _pressing = true;
                _doorAnimator.StopPlayback();
                _doorAnimator.Play("LaserDoorOff", -1, 0f);
                _renderer.sprite = _pressingStateButton;
            }
        }

        if(shootButtonEvent)
        {
            if (collision.gameObject.tag == "Laser")
            {
                _pressing = true;
                _doorAnimator.Play("LaserDoorOff", -1, 0f);
                _renderer.sprite = _pressingStateButton;
                collision.gameObject.SetActive(false);
            }
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        if (_openDoorEvent)
        {

            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Prop")
            {
                _pressing = false;
                _doorAnimator.StopPlayback();
                _doorAnimator.Play("LaserDoor", -1, 0f);
                _renderer.sprite = _normalStateButton;
            }
        }
    }
}
