using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }
    public AnimationCurve curve;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(originalPosition.x, curve.Evaluate((Time.time % curve.length)) +  originalPosition.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
