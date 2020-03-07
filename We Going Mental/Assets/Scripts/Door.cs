using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public float delay;
    public string sceneToLoad;
    public Vector2 playerSpawn;

    private BlackFade blackFade;
    private PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        blackFade = FindObjectOfType<BlackFade>();
        playerMove = FindObjectOfType<PlayerMove>();
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
        BetweenScenesInfo.instance.playerSpawn = playerSpawn;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToLoad);
    }
}
