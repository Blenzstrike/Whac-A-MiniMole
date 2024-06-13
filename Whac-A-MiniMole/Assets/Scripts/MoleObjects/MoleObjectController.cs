using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleObjectController : MonoBehaviour
{
    [HideInInspector] public float LiveTimerInSeconds;
    [HideInInspector] public int TapScore;
    protected float elapsedTime = 0;
    protected bool isJumping = true;
    protected float movementSpeed = 3;

    // Start is called before the first frame update
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
