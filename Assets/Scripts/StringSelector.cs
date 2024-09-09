using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringSelector : MonoBehaviour
{
    [SerializeField]
    Wheel wheel;
    bool[] wedgeStats;
    [SerializeField]
    float wedgeIncrements = 11.25f;
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
    public bool[] GetWedgeStats()
    {
        return wedgeStats;
    }
    public bool IsAnyWedgeActive()
    {
        foreach(bool wedge in wedgeStats)
        {
            if(wedge)
            {
                return true;
            }
        }
        return false;
    }

    void ProcessInput()
    {
        float rotateDeg = 0.0f;
        bool[] tempWedgeStats = new bool[4];

        if (Input.GetKey(KeyCode.A))
        {
            tempWedgeStats[0] = true;
            if (Input.GetKey(KeyCode.S))
            {
                rotateDeg = wedgeIncrements*2;
                tempWedgeStats[1] = true;
            }
            else
            {
                rotateDeg = wedgeIncrements*3;
            }
        }
        else if(Input.GetKey(KeyCode.S))
        {
            tempWedgeStats[1] = true;
            if (Input.GetKey(KeyCode.D))
            {
                rotateDeg = 0.0f;
                tempWedgeStats[2] = true;
            }
            else
            {
                rotateDeg = wedgeIncrements;
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            tempWedgeStats[2] = true;
            if (Input.GetKey(KeyCode.F))
            {
                rotateDeg = -wedgeIncrements*2;
                tempWedgeStats[3] = true;
            }
            else
            {
                rotateDeg = -wedgeIncrements;
            }
        }
        else if (Input.GetKey(KeyCode.F))
        {
            rotateDeg = -wedgeIncrements*3;
            tempWedgeStats[3] = true;
        }
        wedgeStats = tempWedgeStats;
        for(int i = 0; i < wedgeStats.Length; i++)
        {
            wheel.SetWedgeStatus(i, wedgeStats[i]);
        }
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotateDeg);
    }
}
