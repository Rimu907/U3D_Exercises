using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // required to use the Text class
public class TargetGameController : MonoBehaviour
{
    public float timeLeft = 30.0f;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void TargetDestroyed(int timeBonus)
    {
        timeLeft += timeBonus;
        if (GameObject.FindObjectsOfType<DestroyableTarget>().Length == 0)
        {
            Debug.Log("game won");
        }
    }
    // Update is called once per frame
    void Update()
    {
        // format to a string with no decimal places
        timeText.text = timeLeft.ToString("0");

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Debug.Log("game lost");
        }
    }
}
