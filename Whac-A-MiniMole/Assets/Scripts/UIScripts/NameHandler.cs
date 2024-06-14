using TMPro;
using UnityEngine;

/// <summary>
/// Class that handles the field that sets the user name.
/// </summary>
public class NameHandler : MonoBehaviour
{ 
    private TMP_InputField textField;

    void OnEnable()
    {
        textField = GetComponent<TMP_InputField>();
        textField.SetTextWithoutNotify(PlayerInformation.Name);
        textField.onEndEdit.AddListener(OnChangeName);
    }
    private void OnDisable()
    {
        textField.onEndEdit.RemoveListener(OnChangeName);
    }

    private void OnChangeName(string pNewValue)
    {
        PlayerInformation.Name = pNewValue;
    }
}
