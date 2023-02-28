using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProp : MonoBehaviour
{
    public Animator _doorAnimator;
    public Sprite destroyedState;
    SpriteRenderer renderer;
    public BoxCollider2D buttonToDisable;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            
            buttonToDisable.enabled = false;
            DestroyPropVoid();
        }
    }

    public void DestroyPropVoid()
    {
        _doorAnimator.Play("LaserDoorOff", -1, 0f);
        renderer.sprite = destroyedState;
    }
}
