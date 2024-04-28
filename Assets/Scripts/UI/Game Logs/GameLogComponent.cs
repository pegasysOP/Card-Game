using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogComponent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private LayoutElement layoutElement;

    public void Init(string message)
    {
        timeText.text = DateTime.Now.ToString("HH:mm:ss");
        messageText.text = message;
        
        RecalculateHeight();
    }

    private void RecalculateHeight()
    {
        float padding = -messageText.rectTransform.sizeDelta.y;

        layoutElement.preferredHeight = messageText.GetPreferredValues().y + padding;
    }

}
