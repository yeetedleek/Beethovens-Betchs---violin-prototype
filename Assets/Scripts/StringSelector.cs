using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringSelector : MonoBehaviour
{
    [SerializeField]
    Wheel wheel;
    bool[] wedgeStats;
    // Start is called before the first frame update
    void Start()
    {
        wedgeStats = new bool[4];
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        float rotateDeg = 0.0f;
        for(int i = 0; i < wedgeStats.Length; i++)
        {
            wedgeStats[i] = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            wedgeStats[0] = true;
            if (Input.GetKey(KeyCode.S))
            {
                rotateDeg = 45f;
                wedgeStats[1] = true;
            }
            else
            {
                rotateDeg = 67.5f;
            }
        }
        else if(Input.GetKey(KeyCode.S))
        {
            wedgeStats[1] = true;
            if (Input.GetKey(KeyCode.D))
            {
                rotateDeg = 0.0f;
                wedgeStats[2] = true;
            }
            else
            {
                rotateDeg = 22.5f;
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            wedgeStats[2] = true;
            if (Input.GetKey(KeyCode.F))
            {
                rotateDeg = -45f;
                wedgeStats[3] = true;
            }
            else
            {
                rotateDeg = -22.5f;
            }
        }
        else if (Input.GetKey(KeyCode.F))
        {
            rotateDeg = -67.5f;
            wedgeStats[3] = true;
        }
        for(int i = 0; i < wedgeStats.Length; i++)
        {
            wheel.SetWedgeStatus(i, wedgeStats[i]);
        }
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotateDeg);
    }
}
