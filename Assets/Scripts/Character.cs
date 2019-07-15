using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Character : MonoBehaviour, IDialogue
{
    public string cname;
    public GameObject costume;
    public List<List<string>> curLines { get; set; }
    private int i;
    private int j;
    public bool isTalking;

    private void Awake()
    {
        curLines = new List<List<string>>();
    }

    private void Update()
    {
        if (isTalking)
        {
            NPCTalk();
        }
    }
    private void NPCTalk()
    {
        if (i < curLines.Count)
        {
            if (j < curLines[i].Count)
            {
                Debug.Log(curLines[i][j]);
                j++;
            }
            else
            {
                j = 0;
                i++;
                isTalking = false;
            }
        }
    }
    public string NextLine
    {
        get { return curLines[0][0]; }

        set => throw new System.NotImplementedException();
    }

}
