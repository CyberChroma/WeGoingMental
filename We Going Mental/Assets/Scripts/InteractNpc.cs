using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNpc : MonoBehaviour
{
    public string[] text;
    public string[] characterTalking;
    public Transform[] talkPoints;

    private GameObject textBox;
    private DisplayText displayText;
    private PlayerMove playerMove;
    private PlayerInteract playerInteract;
    private Follow cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GameObject.Find("Text Box Controller").transform.Find("Text Box").gameObject;
        displayText = FindObjectOfType<DisplayText>();
        playerMove = FindObjectOfType<PlayerMove>();
        playerInteract = FindObjectOfType<PlayerInteract>();
        cameraFollow = GameObject.Find("Cam Follow").GetComponent<Follow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInteraction()
    {
        StartCoroutine(WaitForInteraction());
    }

    IEnumerator WaitForInteraction ()
    {
        playerMove.enabled = false;
        textBox.SetActive(true);
        for (int i = 0; i < text.Length; i++)
        {
            displayText.ShowText(text[i], characterTalking[i] == "Cam", characterTalking[i]);
            cameraFollow.target = talkPoints[i];
            yield return new WaitForSeconds(0.1f);
            while (!Input.GetKeyDown(KeyCode.E))
            {
                yield return null;
            }
        }
        textBox.SetActive(false);
        cameraFollow.target = playerMove.transform;
        playerMove.enabled = true;
        yield return new WaitForSeconds(0.1f);
        playerInteract.interacting = false;
    }
}
