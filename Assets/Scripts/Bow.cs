using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    Vector3 mousePos;
    [SerializeField]
    float moveSpeed = 0.1f;
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
        transform.localPosition = new Vector3(Mathf.Clamp(mousePos.x,-2.5f, 4.5f), currPos.y, currPos.z);
    }
}
