using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public float delay;
    public Transform moveToPoint;

    private BlackFade blackFade;
    private PlayerMove playerMove;
    private PlayerInteract playerInteract;
    private Transform camFollow;

    // Start is called before the first frame update
    void Start()
    {
        blackFade = FindObjectOfType<BlackFade>();
        playerMove = FindObjectOfType<PlayerMove>();
        playerInteract = FindObjectOfType<PlayerInteract>();
        camFollow = FindObjectOfType<Follow>().transform;
    }

    public void Transition()
    {
        StartCoroutine(FadeAndLoad());
    }

    IEnumerator FadeAndLoad()
    {
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
