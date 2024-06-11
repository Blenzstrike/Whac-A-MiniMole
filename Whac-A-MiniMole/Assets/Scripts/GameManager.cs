using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private HoleSpawner holeSpawner;
    [SerializeField] private TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.OnStartGame.AddListener(StartGame);
    }

    private void StartGame()
    {
        mainMenu.gameObject.SetActive(false);
        int _requiredHoles = 1;
        if(int.TryParse(inputField.text, out _requiredHoles))
        {
            if (_requiredHoles < 0) _requiredHoles = 1;
        }
        holeSpawner.SpawnHoles(_requiredHoles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
