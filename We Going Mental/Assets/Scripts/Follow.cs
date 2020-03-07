using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float smoothing;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
    }
}
