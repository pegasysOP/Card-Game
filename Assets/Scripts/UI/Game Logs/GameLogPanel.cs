using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogPanel : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Transform contentTransform;
    [SerializeField] private GameLogComponent logComponentPrefab;
    [SerializeField] private int maxLogCount;

    private List<GameLogComponent> logComponents = new List<GameLogComponent>();

    private void Update()
    {
        // for testing
        if (Input.GetKeyDown(KeyCode.L))
        {
            switch (Random.Range(0, 6))
            {
                case 0:
                    AddLogComponent("You drew a card");
                    break;
                case 1:
                    AddLogComponent("You played a card");
                    break;
                case 2:
                    AddLogComponent("You discarded a card");
                    break;
                case 3:
                    AddLogComponent("Enemy drew a card");
                    break;
                case 4:
                    AddLogComponent("Enemy played a card");
                    break;
                case 5:
                    AddLogComponent("Enemy discarded a card");
                    break;
            }
        }
    }

    private void AddLogComponent(string message)
    {
        GameLogComponent logComponent = Instantiate(logComponentPrefab, contentTransform);
        logComponent.Init(message);
        logComponents.Add(logComponent);

        // remove oldest log component if going over the limit
        if (logComponents.Count > maxLogCount)
        {
            GameLogComponent oldestComponent = logComponents[0];
            logComponents.RemoveAt(0);
            Destroy(oldestComponent.gameObject);
        }

        // scroll to the bottom to show new message
        StartCoroutine(DelayedScrollToBottom());
    }

    private IEnumerator DelayedScrollToBottom()
    {
        yield return new WaitForEndOfFrame();

        scrollRect.verticalNormalizedPosition = 0f;
    }
}
