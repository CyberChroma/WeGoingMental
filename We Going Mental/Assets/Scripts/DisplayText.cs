using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public GameObject textBox;
    public GameObject playerNameTextBox;
    public GameObject npcNameTextBox;
    public Text mainText;
    public Text playerText;
    public Text npcText;

    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
        playerNameTextBox.SetActive(false);
        npcNameTextBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowText(string text, bool player, string name)
    {
        if (player)
        {
            playerNameTextBox.SetActive(true);
            npcNameTextBox.SetActive(false);
            playerText.text = name;
        }
        else
        {
            playerNameTextBox.SetActive(false);
            npcNameTextBox.SetActive(true);
            npcText.text = name;
        }
        mainText.text = text;
    }
}
