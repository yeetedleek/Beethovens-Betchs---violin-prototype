using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField]
    Wedge[] wedges;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWedgeStatus(ViolinStrings activeStrings)
    {
        bool[] wedgeStats = new bool[wedges.Length];
        int temp = (int)activeStrings;
        if(activeStrings != ViolinStrings.None)
        {
            wedgeStats[temp / 2] = true;
            if(temp % 2 != 0)
            {
                wedgeStats[(temp / 2) + 1] = true;
            }
        }
        for(int i = 0; i < wedges.Length; i++)
        {
            wedges[i].SetSpriteActive(wedgeStats[i]);
        }
    }
}
