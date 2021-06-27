using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    public bool inRange = false;
    public Inventory inventory;
    public GameObject key;

    private void OnTriggerEnter(Collider other)
    {
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController f
            = other.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        if(f!=null)
            inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {   
        
        inRange = false;
    }

    void Start()
    {
        // register with the event handler
        inventory.ItemUsed += Inventory_ItemUsed;
    }


    void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        // check if the correct item is in use
        if ((e.item as MonoBehaviour).gameObject == key)
        {
            // check if in range
            if (inRange)
            {
                gameObject.GetComponent<Door>().Open();
                inventory.removeItem(key.GetComponent<IInventoryItem>());
            }
        }
    }

    private IEnumerator DoorAnim(int targetAngle)
    {
        float currentAngle = transform.localEulerAngles.y;

        for(float r=0.0f; r<1.0f; r+=0.01f)
        {
            transform.localEulerAngles = new Vector3(0, Mathf.LerpAngle(currentAngle, targetAngle, r), 0);
            yield return null;
        }
    }

    public void Open()
    {
        StartCoroutine(DoorAnim(90));
    }



}
