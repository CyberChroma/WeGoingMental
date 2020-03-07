using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenScenesInfo : MonoBehaviour
{
    public static BetweenScenesInfo instance = null;

    public Vector2 playerSpawn;
    public string[] inventory;
        
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

    public void setPlayerPosition ()
    {
        FindObjectOfType<PlayerMove>().transform.position = playerSpawn;
    }
}
