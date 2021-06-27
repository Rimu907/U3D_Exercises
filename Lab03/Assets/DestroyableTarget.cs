using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableTarget : MonoBehaviour
{// script for the target
    public int timeBonus = 10;
    TargetGameController GameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            GameController = gameControllerObject.GetComponent<TargetGameController>();
        }
        if (GameController == null)
        {
            Debug.Log("Cannot find TargerGameController");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        // destroy this object
        DestroyObject(gameObject);
    }
    private void OnDestroy()
    {
        // tell the game controller
        if (GameController != null)
        {
            GameController.TargetDestroyed(timeBonus);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
