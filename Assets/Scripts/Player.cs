using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    float timeLeeLeeway = 0.3f;
    float playTime = 0;
    ViolinStrings lastPlayedStrings;

    SpriteRenderer spriteRenderer;
    SpriteManager spriteManager;
    GameObject bowObject;
    StringSelector stringSelector;
    Bow bow;
    Simon simon;
    PlayTimer playTimer;
    TextMeshProUGUI playTimeText;

    bool wasPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteManager = GameObject.FindGameObjectWithTag("SpriteManager").GetComponent<SpriteManager>();
        bowObject = GameObject.FindGameObjectWithTag("Bow");
        stringSelector = bowObject.GetComponent<StringSelector>();
        bow = bowObject.GetComponentInChildren<Bow>();
        simon = GameObject.FindGameObjectWithTag("Simon").GetComponent<Simon>();
        playTimer = gameObject.AddComponent<PlayTimer>();
        playTimeText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        lastPlayedStrings = ViolinStrings.None;
    }

    // Update is called once per frame
    void Update()
    {
        ViolinStrings activeStrings = ViolinStrings.None;
        if(bow.GetIsMoving() && stringSelector.IsAnyWedgeActive())
        {
            activeStrings = stringSelector.GetActiveStrings();
            playTimeText.text = playTimer.GetPlayTime().ToString("F3");
            if(simon.IsNoteInQueue())
            {
                playTimer.StartPlayTimer();
            }
        }
        else
        {
            if(playTimer.IsTimerRunning())
            {
                if (simon.IsNoteInQueue())
                {
                    playTime = playTimer.GetPlayTime();
                    Note note = simon.GetCurrentNote();
                    float noteLength = note.Length();
                    //check correct string and time
                    if (
                        lastPlayedStrings == note.Strings() && 
                        playTime > noteLength - timeLeeLeeway && 
                        playTime < noteLength + timeLeeLeeway
                        )
                    {
                        simon.CompleteNote();
                    }
                    else
                    {
                        simon.Failed();

                    }
                }
                playTimer.ResetPlayTimer();
            }
        }
        spriteRenderer.sprite = spriteManager.GetNoteSprite(activeStrings);
        lastPlayedStrings = activeStrings;
    }



}
