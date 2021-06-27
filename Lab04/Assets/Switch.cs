using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Door doorObject;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        doorObject.Open();
    }
    private void OnTriggerExit(Collider other)
    {
        doorObject.Close();
    }
    // Update is called once per frame

    
}
