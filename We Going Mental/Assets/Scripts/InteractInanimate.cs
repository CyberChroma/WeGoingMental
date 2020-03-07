﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInanimate : MonoBehaviour
{
    public string[] text;

    private GameObject textBox;
    private DisplayText displayText;
    private PlayerMove playerMove;
    private PlayerInteract playerInteract;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GameObject.Find("Text Box Controller").transform.Find("Text Box").gameObject;
        displayText = FindObjectOfType<DisplayText>();
        playerMove = FindObjectOfType<PlayerMove>();
        playerInteract = FindObjectOfType<PlayerInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInteraction()
    {
        playerMove.enabled = false;
        StartCoroutine(WaitForInteraction());
    }

    IEnumerator WaitForInteraction ()
    {
        textBox.SetActive(true);
        for (int i = 0; i < text.Length; i++)
        {
            displayText.ShowText(text[i], true, "Cam");
            yield return new WaitForSeconds(0.1f);
            while (!Input.GetKeyDown(KeyCode.E))
            {
                yield return null;
            }
        }
        textBox.SetActive(false);
        playerMove.enabled = true;
        yield return new WaitForSeconds(0.1f);
        playerInteract.interacting = false;
    }
}
