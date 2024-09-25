using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    TextMeshProUGUI tmp;
    SpriteManager spriteManager;
    SpriteRenderer spriteRenderer;
    ViolinStrings violinStrings;
    float noteLength;
    float spriteSize;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void InitializeNote(ViolinStrings strings, float length)
    {
        spriteManager = GameObject.FindGameObjectWithTag("SpriteManager").GetComponent<SpriteManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        violinStrings = strings;
        noteLength = length;
        spriteRenderer.sprite = spriteManager.GetNoteSprite(violinStrings);
        spriteSize = spriteRenderer.bounds.size.x;
    }
    public float SpriteSize()
    {
        return spriteSize;
    }

    public float Length()
    {
        return noteLength;
    }

    public ViolinStrings Strings()
    {
        return violinStrings;
    }

    public void Disappear()
    {
        spriteRenderer.enabled = false;
        tmp.enabled = false;
    }
    public void Appear()
    {
        spriteRenderer.enabled = true;
        tmp.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = noteLength.ToString("F1");
    }
}