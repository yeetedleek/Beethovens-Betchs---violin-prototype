using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayIndicator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Bow bow;
    [SerializeField]
    StringSelector stringSelector;
    [SerializeField]
    Sprite defaultSprite;
    [SerializeField]
    Sprite redSprite;
    [SerializeField]
    Sprite yellowRedSprite;
    [SerializeField]
    Sprite yellowSprite;
    [SerializeField]
    Sprite greenYellowSprite;
    [SerializeField]
    Sprite greenSprite;
    [SerializeField]
    Sprite blueGreenSprite;
    [SerializeField]
    Sprite blueSprite;

    PlayTimer timer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        timer = gameObject.GetComponent<PlayTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bow.GetIsMoving() && stringSelector.IsAnyWedgeActive())
        {
            timer.StartPlayTimer();
            bool[] stats = stringSelector.GetWedgeStats();
            if (stats[0])
            {
                if (stats[1])
                {
                    spriteRenderer.sprite = blueGreenSprite;
                }
                else
                {
                    spriteRenderer.sprite = blueSprite;
                }
            }
            else if(stats[1])
            {
                if (stats[2])
                {
                    spriteRenderer.sprite = greenYellowSprite;
                }
                else
                {
                    spriteRenderer.sprite = greenSprite;
                }
            }
            else if (stats[2])
            {
                if (stats[3])
                {
                    spriteRenderer.sprite = yellowRedSprite;
                }
                else
                {
                    spriteRenderer.sprite = yellowSprite;
                }
            }
            else if (stats[3])
            {
                spriteRenderer.sprite = redSprite;
            }
        }
        else
        {
            spriteRenderer.sprite = defaultSprite;
            timer.ResetPlayTimer();
        }

    }
}
