using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLoad : MonoBehaviour
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
        yield return new WaitForSeconds(delay);    
        BetweenScenesInfo.instance.playerSpawn = playerSpawn;
        SceneManager.LoadScene(sceneToLoad);
    }
}
