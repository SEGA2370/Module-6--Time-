using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{

    public Text timerText;
    public Text lapText;
    private float currentTime;

    private int lapsNumber = 0;

    public Text lapTimeText;
    private float currentLapTime;

    public Text previousLapTimeText;
    private float previousLapTime;    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime = Mathf.Round(Time.time);
        timerText.text = currentTime.ToString();
        
    }

    public void LapsFinishedButtonCLick() 
    {
        CalculateRaceData();
        DisplayRaceData();
    }

    private void CalculateRaceData()
    {
        previousLapTime = currentLapTime;
        currentLapTime = currentTime;
        lapsNumber = lapsNumber + 1;
    }
    private void DisplayRaceData() 
    {
        lapTimeText.text = currentLapTime.ToString();
        previousLapTimeText.text = previousLapTime.ToString();
        lapText.text = lapsNumber.ToString();
    }
}
