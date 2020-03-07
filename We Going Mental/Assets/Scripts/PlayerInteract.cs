using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [HideInInspector] public bool interacting = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!interacting && Input.GetKeyDown(KeyCode.E) && collision.gameObject.layer == 9)
        {
            if (collision.CompareTag("Door"))
            {
                collision.GetComponent<Door>().Transition();
            }
            else if (collision.CompareTag("InteractInanimate"))
            {
                collision.GetComponent<InteractInanimate>().StartInteraction();
            }
            else if (collision.CompareTag("InteractNpc"))
            {
                collision.GetComponent<InteractNpc>().StartInteraction();
            }
            interacting = true;
        }
    }
}
