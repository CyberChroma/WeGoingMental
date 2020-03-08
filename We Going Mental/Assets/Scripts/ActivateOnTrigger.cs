using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTrigger : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectToActivate.SetActive(true);
        gameObject.SetActive(false);
    }
}
