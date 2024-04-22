using System;
using TMPro;
using UnityEngine;

public class GameLogComponent : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI messageText;

    public void Init(string message)
    {
        timeText.text = DateTime.Now.ToString("HH:mm:ss");
        messageText.text = message;
    }
}
