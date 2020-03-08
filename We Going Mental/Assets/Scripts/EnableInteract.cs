using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableInteract : MonoBehaviour
{
    public GameObject toEnable;
    public GameObject toDisable;
    public GameObject[] interacts;

    private bool activated;

    // Start is called before the first frame update
    void Start()
    {
        toEnable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        activated = true;
        foreach (GameObject interactable in interacts)
        {
            if (interactable.activeSelf)
            {
                activated = false;
            }
        }
        if (activated)
        {
            toEnable.SetActive(true);
            toDisable.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
