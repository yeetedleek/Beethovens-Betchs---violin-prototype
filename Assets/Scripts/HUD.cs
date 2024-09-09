using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    PlayTimer timer;
    [SerializeField]
    TextMeshProUGUI tmp;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = timer.GetPlayTime().ToString();
    }
}
