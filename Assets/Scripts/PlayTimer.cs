using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimer : MonoBehaviour
{
    bool isTimerRunning = false;
    float currTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ResetPlayTimer()
    {
        isTimerRunning = false;
        currTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(isTimerRunning)
        {
            currTime += Time.deltaTime;
        }
    }
    public void StartPlayTimer()
    {
        isTimerRunning = true;
    }

    public float GetPlayTime()
    {
        return currTime;
    }
}
