using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class NameHandler : MonoBehaviour
{
    private TMP_InputField textField;
    // Start is called before the first frame update
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
