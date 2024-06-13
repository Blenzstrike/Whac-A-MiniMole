using UnityEngine;
using UnityEngine.UI;

public class NameSetter : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Text>().text = PlayerInformation.Name;
    }
}
