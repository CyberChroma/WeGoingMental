using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [HideInInspector] public bool interacting = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!interacting && Input.GetKeyDown(KeyCode.E) && collision.gameObject.layer == 9 || collision.gameObject.layer == 10)
        {
            if (collision.CompareTag("DoorMove"))
            {
                collision.GetComponent<DoorMove>().Transition();
            }
            else if (collision.CompareTag("DoorLoad"))
            {
                collision.GetComponent<DoorLoad>().Transition();
            }
            else if (collision.CompareTag("InteractInanimate"))
            {
                collision.GetComponent<InteractInanimate>().StartInteraction();
            }
            else if (collision.CompareTag("InteractNpc"))
            {
                collision.GetComponent<InteractNpc>().StartInteraction();
            }
            else if (collision.CompareTag("InteractFade"))
            {
                collision.GetComponent<InteractAndMove>().InteractAndFade();
            }
            interacting = true;
        }
    }
}
