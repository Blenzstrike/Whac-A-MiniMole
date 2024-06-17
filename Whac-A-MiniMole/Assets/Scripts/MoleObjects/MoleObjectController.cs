using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Base class that controls all mole objects. 
/// </summary>
public class MoleObjectController : MonoBehaviour
{
    /// <summary>
    /// Time that the mole needs to stay alive
    /// </summary>
    [HideInInspector] public float LiveTimerInSeconds;
    /// <summary>
    /// Score that you get if tapped
    /// </summary>
    [HideInInspector] public int TapScore;
    /// <summary>
    /// Time that has passed in seconds since the start of the run.
    /// </summary>
    protected float elapsedTime = 0;
    /// <summary>
    /// Wether the object is moving up or down.
    /// </summary>
    protected bool isJumping = true;
    /// <summary>
    /// Movement speed of the object.
    /// </summary>
    protected float movementSpeed = 3;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnObjectSelected);
    }

    private void OnObjectSelected()
    {
        PlayerInformation.Score += TapScore;
        DestroyThisObject();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > LiveTimerInSeconds)
        {
            DestroyThisObject();
        }
        else
        {
            MoveObject();
        }
    }

    protected virtual void MoveObject() {
        if (elapsedTime > (LiveTimerInSeconds / 2)) { isJumping = false; }
        if (isJumping)
        {
            transform.position += new Vector3(0, movementSpeed, 0);
        }
        else
        {
            transform.position -= new Vector3(0, movementSpeed, 0);
        }
    }

    private void DestroyThisObject()
    {
        Destroy(gameObject);
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
