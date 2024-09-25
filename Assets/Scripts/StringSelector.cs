using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringSelector : MonoBehaviour
{
    [SerializeField]
    Wheel wheel;
    ViolinStrings activeStrings = ViolinStrings.None;
    [SerializeField]
    float wedgeIncrements = 11.25f;
    [SerializeField]
    int skipFrames = 8;
    int frameCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(++frameCnt > skipFrames)
        {
            frameCnt = 0;
            ProcessInput();
            wheel.SetWedgeStatus(activeStrings);
        }
    }
    public ViolinStrings GetActiveStrings()
    {
        return activeStrings;
    }
    public bool IsAnyWedgeActive()
    {
        if(activeStrings == ViolinStrings.None)
        {
            return false;
        }
        return true;
    }

    void ProcessInput()
    {
        float rotateDeg = 0.0f;
        ViolinStrings tempStrings = ViolinStrings.None;

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.S))
            {
                tempStrings = ViolinStrings.BlueGreen;
                rotateDeg = wedgeIncrements*2;
            }
            else
            {
                tempStrings = ViolinStrings.Blue;
                rotateDeg = wedgeIncrements*3;
            }
        }
        else if(Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.D))
            {
                tempStrings = ViolinStrings.GreenYellow;
                rotateDeg = 0.0f;
            }
            else
            {
                tempStrings = ViolinStrings.Green;
                rotateDeg = wedgeIncrements;
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {

            if (Input.GetKey(KeyCode.F))
            {
                rotateDeg = -wedgeIncrements*2;
                tempStrings = ViolinStrings.YellowRed;
            }
            else
            {
                tempStrings = ViolinStrings.Yellow;
                rotateDeg = -wedgeIncrements;
            }
        }
        else if (Input.GetKey(KeyCode.F))
        {
            rotateDeg = -wedgeIncrements*3;
            tempStrings = ViolinStrings.Red;
        }
        activeStrings = tempStrings;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotateDeg);
    }
}
