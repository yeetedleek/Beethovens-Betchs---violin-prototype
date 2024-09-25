using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{
    [SerializeField]
    int maxNotes = 5;
    [SerializeField]
    float minNoteTime = 0.5f;
    [SerializeField]
    float maxNoteTime = 2.5f;
    [SerializeField]
    float xIncrement = 5f;
    [SerializeField]
    float yPosition = 2.5f;
    [SerializeField]
    GameObject prefabNote;
    [SerializeField]
    List<GameObject> playQueue;

    int currentNoteIdx = 0;
    HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        GenerateQueue();
        ResetNotes();
        AlignNotes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CompleteNote()
    {
        if(++currentNoteIdx < playQueue.Count)
        {
            playQueue[currentNoteIdx - 1].GetComponent<Note>().Disappear();
        }
        else
        {
            GenerateQueue();
            ResetNotes();
        }
        AlignNotes();
    }

    public void Failed()
    {
        hud.NO();
        ResetNotes();
        AlignNotes();
    }

    void ResetNotes()
    {
        currentNoteIdx = 0;
        foreach (GameObject note in playQueue)
        {
            note.GetComponent<Note>().Appear();
        }
    }

    void GenerateQueue()
    {
        ClearNotes();
        int numNotesThisQueue = Random.Range(2, maxNotes);
        for(int i = 0; i < numNotesThisQueue; i++)
        {
            int randString = Random.Range(0, 7);
            float randTime = Random.Range(minNoteTime, maxNoteTime);
            GameObject note = Instantiate(prefabNote);
            note.GetComponent<Note>().InitializeNote((ViolinStrings)randString, randTime);
            playQueue.Add(note);
        }
    }
    void AlignNotes()
    {
        int totalNotes = playQueue.Count;
        int numNotes = totalNotes - currentNoteIdx;
        if(totalNotes == 0)
        {
            return;
        }

        float spriteSize = playQueue[0].GetComponent<Note>().SpriteSize();
        float totalWidth = spriteSize * numNotes + xIncrement * (numNotes - 1);
        float startingX = -(totalWidth / 2) + (spriteSize / 2);

        for(int i = currentNoteIdx; i < playQueue.Count; i++)
        {
            GameObject note = playQueue[i];
            note.transform.position = new Vector3(startingX + ((i-currentNoteIdx) * (spriteSize + xIncrement)), yPosition, 0);
        }
    }
    public bool IsNoteInQueue()
    {
        return playQueue.Count > 0;
    }

    public Note GetCurrentNote()
    {
        return playQueue[currentNoteIdx].GetComponent<Note>();
    }
     public void ClearNotes()
    {
        foreach (GameObject note in playQueue)
        {
            Destroy(note);
        }
        playQueue.Clear();
    }

}
