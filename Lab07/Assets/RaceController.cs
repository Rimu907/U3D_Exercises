using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class RaceController : MonoBehaviour
{
    RaceState raceState;
    enum RaceState
    {
        START,
        RACING,
        FINISHED
    };
    public Text resultText;
    public Text timeText;
    float startTime;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCountdown());
        raceState = RaceState.START;
    }
    IEnumerator startCountdown()
    {
        int count = 3;
        while (count > 0)
        {
            resultText.text = "" + count+"...";
            count--;
            yield return new WaitForSeconds(1);
        }
        raceState = RaceState.RACING;
        startTime = Time.time;
        resultText.text = "GO";
        GameObject[] AICar = GameObject.FindGameObjectsWithTag("AICAR");
        foreach(GameObject car in AICar)
        {
            car.GetComponent<CarAIControl>().enabled  = true;
        }
        yield return new WaitForSeconds(1);
        resultText.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (raceState == RaceState.RACING)
        {
            timeText.text = "" + (Time.time - startTime);
        }
    }
    IEnumerator endRace()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        raceState = RaceState.FINISHED;
        //returing to the menu
        StartCoroutine(endRace());
        scoreManager.setTime((Time.time - startTime), SceneManager.GetActiveScene().buildIndex);
    }
}
