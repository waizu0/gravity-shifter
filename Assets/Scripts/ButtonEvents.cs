using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public bool _openDoorEvent;
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
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Prop")
        {
            _pressing = true;
            _doorAnimator.Play("MetalDoorOn", -1, 0f);
            _renderer.sprite = _pressingStateButton;
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Prop")
        {
            _pressing = false;
            _doorAnimator.Play("MetalDoorOff", -1, 0f);
            _renderer.sprite = _normalStateButton;
        }
    }
}
