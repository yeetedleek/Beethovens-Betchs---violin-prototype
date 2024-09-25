using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    Vector3 mousePos;

    [SerializeField]
    float bowClampMin = -2.5f;
    [SerializeField]
    float bowClampMax = 4.5f;


    float clampedBowPos;

    bool isMoving = false;
    float prevMouseMovement =0;
    float currMouseMovement =0;

    [SerializeField]
    int skipFrames = 8;
    int frameCnt = 0;
    public bool GetIsMoving()
    {
        return isMoving;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPos = transform.localPosition;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        clampedBowPos = Mathf.Clamp(mousePos.x, bowClampMin, bowClampMax);
        transform.localPosition = new Vector3(clampedBowPos, currPos.y, currPos.z);
        if(frameCnt < skipFrames)
        {
            frameCnt++;
            currMouseMovement += Input.GetAxisRaw("Mouse X");
        }
        else
        {
            frameCnt = 0;
            if(currMouseMovement != 0)
            {
                isMoving = true;
                if(Mathf.Sign(prevMouseMovement) != Mathf.Sign(currMouseMovement))
                {
                    //bow moved other way play note attack
                    isMoving = false;
                }
            }
            else
            {
                isMoving = false;
            }
            prevMouseMovement = currMouseMovement;
            currMouseMovement = 0;
        }
    }
}
