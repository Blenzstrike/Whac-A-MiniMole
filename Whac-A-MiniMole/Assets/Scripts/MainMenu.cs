using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    public UnityEvent OnStartGame;

    private void OnEnable()
    {
        startGameButton.onClick.AddListener(OnStartGamePress);
    }

    private void OnDisable()
    {
        startGameButton.onClick.RemoveListener(OnStartGamePress);
    }

    private void OnStartGamePress()
    {
        OnStartGame.Invoke();
    }
}
