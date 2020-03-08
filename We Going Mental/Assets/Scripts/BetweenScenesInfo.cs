using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetweenScenesInfo : MonoBehaviour
{
    public static BetweenScenesInfo instance = null;

    public Vector2 playerSpawn;
        
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            instance.setPlayerPosition();
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void setPlayerPosition ()
    {
        FindObjectOfType<PlayerMove>().transform.position = playerSpawn;
    }
}
