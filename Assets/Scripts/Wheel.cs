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

    public void SetWedgeStatus(int index, bool input)
    {
        if(index < wedges.Length)
        {
            wedges[index].SetSpriteActive(input);
        }
    }
}
