using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void OnEnable()
    {
        Destroy(gameObject, time);
    }
}
