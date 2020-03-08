using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    public float outSmoothing;
    public float inSmoothing;

    [HideInInspector] public bool fadeBlack;
    [HideInInspector] public bool fading;

    private Image blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        fading = true;
        fadeBlack = false;
        blackScreen = GetComponent<Image>();
        blackScreen.color = new Color(0, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            if (fadeBlack)
            {
                blackScreen.color = Color.Lerp(blackScreen.color, new Color(0, 0, 0, 1), outSmoothing * Time.deltaTime);
                if (blackScreen.color.a >= 0.95f)
                {
                    blackScreen.color = new Color(0, 0, 0, 1);
                    fading = false;
                }
            }
            else
            {
                blackScreen.color = Color.Lerp(blackScreen.color, new Color(0, 0, 0, 0), inSmoothing * Time.deltaTime);
                if (blackScreen.color.a <= 0.05f)
                {
                    blackScreen.color = new Color(0, 0, 0, 0);
                    fading = false;
                }
            }
        }
    }
}
