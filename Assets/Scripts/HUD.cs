using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI noText;
    [SerializeField]
    float NOTime = 0.5f;
    PlayTimer timerNO;



    // Start is called before the first frame update
    void Start()
    {
        timerNO = gameObject.AddComponent<PlayTimer>();
        noText.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(timerNO.IsTimerRunning())
        {
            if(timerNO.GetPlayTime() > NOTime)
            {
                timerNO.ResetPlayTimer();
                noText.alpha = 0;
            }
        }
    }

    public void NO()
    {
        timerNO.StartPlayTimer();
        noText.alpha = 0xFF;
    }
}
