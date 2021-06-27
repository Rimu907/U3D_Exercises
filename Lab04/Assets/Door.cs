using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public void Open()
    {
        Debug.Log("opening");
        StartCoroutine(DoorAnimation(90, 100));
    }
    public void Close()
    {
        Debug.Log("closing");
        StartCoroutine(DoorAnimation(0, 100));
    }
    private IEnumerator DoorAnimation(int targetAngle, int animationSpeed)
    {
        for (int r = 0; r < animationSpeed; r += 1)
        {
            transform.localEulerAngles = new Vector3(0, Mathf.LerpAngle(transform.localEulerAngles.y, targetAngle, 5f / animationSpeed), 0);
            yield return null;
        }
    }
}
