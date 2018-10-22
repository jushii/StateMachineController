using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text playerStateMachineLabel = null;

    internal void SetPlayerStateMachineLabel(string text)
    {
        this.playerStateMachineLabel.text = text;
    }
}
