using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wedge : MonoBehaviour
{
    [SerializeField]
    Sprite activeSprite;
    [SerializeField]
    Sprite inactiveSprite;
    
    
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetSpriteActive(bool input)
    {
        if (input)
        {
            spriteRenderer.sprite = activeSprite;
        }
        else
        {
            spriteRenderer.sprite = inactiveSprite;
        }
    }
}
