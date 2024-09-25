using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] noteSprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetNoteSprite(ViolinStrings violinStrings)
    {
        return noteSprites[(int)violinStrings];
    }
}
