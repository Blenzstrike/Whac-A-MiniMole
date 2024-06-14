using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script that set the name on an object that has a text aswell. 
/// </summary>
public class NameSetter : MonoBehaviour
{
    private void OnEnable()
    {
        //Take the name from the player infomration and set it to the text on this object.
        GetComponent<Text>().text = PlayerInformation.Name;
    }
}
