using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{
    public Text highScoreText;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "" + scoreManager.bestTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
