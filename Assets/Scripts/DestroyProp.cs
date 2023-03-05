using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProp : MonoBehaviour
{
    // Reference to the animator component of the door
    public Animator doorAnimator;

    // Sprite to show when the prop is destroyed
    public Sprite destroyedState;

    // Reference to the sprite renderer component of the prop
    private SpriteRenderer propRenderer;

    // Reference to the button collider that needs to be disabled when the prop is destroyed
    public BoxCollider2D buttonColliderToDisable;

    private void Awake()
    {
        // Initialize the sprite renderer reference
        propRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding with the prop has the "Laser" tag and the prop is not already destroyed
        if (collision.CompareTag("Laser") && propRenderer.sprite != destroyedState)
        {
            // Disable the button collider
            buttonColliderToDisable.enabled = false;

            // Call the method to destroy the prop
            DestroyPropAndDisableButton();
        }
    }

    public void DestroyPropAndDisableButton()
    {
        // Play the "LaserDoorOff" animation of the door animator from the beginning
        doorAnimator.Play("LaserDoorOff", -1, 0f);

        // Change the sprite of the prop to the destroyed state sprite
        propRenderer.sprite = destroyedState;
    }
}
