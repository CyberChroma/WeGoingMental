using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAndMove : MonoBehaviour
{
    public float delay;
    public Transform moveToPoint;

    private BlackFade blackFade;
    private PlayerMove playerMove;
    private PlayerInteract playerInteract;
    private Transform camFollow;

    public string[] text;
    public string[] characterTalking;
    public Transform[] talkPoints;

    private GameObject textBox;
    private DisplayText displayText;
    private Follow cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        blackFade = FindObjectOfType<BlackFade>();
        playerMove = FindObjectOfType<PlayerMove>();
        playerInteract = FindObjectOfType<PlayerInteract>();
        camFollow = FindObjectOfType<Follow>().transform;

        textBox = GameObject.Find("Text Box Controller").transform.Find("Text Box").gameObject;
        displayText = FindObjectOfType<DisplayText>();
        cameraFollow = GameObject.Find("Cam Follow").GetComponent<Follow>();
    }

    public void InteractAndFade()
    {
        StartCoroutine(InteractFade());
    }

    IEnumerator InteractFade()
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
        yield return new WaitForSeconds(0.1f);
        playerMove.enabled = false;
        blackFade.fadeBlack = true;
        blackFade.fading = true;
        yield return new WaitForSeconds(delay);
        playerMove.transform.position = moveToPoint.position;
        camFollow.position = moveToPoint.position;
        blackFade.fadeBlack = false;
        blackFade.fading = true;
        playerMove.enabled = true;
        playerInteract.interacting = false;
    }
}
