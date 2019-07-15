using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesManager:MonoBehaviour
{
    public List<List<string>> Lines;
    //public List<string> curDialogue;
    private int i;
    private int j;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame  
    void Update()
    {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (i < Lines.Count)
                    {
                        if (j < Lines[i].Count)
                        {
                            Debug.Log(Lines[i][j]);
                            j++;
                        }
                        else
                        {
                            j = 0;
                            i++;
                            Debug.Log("close window");
                        }
                    }
            }
            //check if there's a list at position i
            //check if there's dialogue at list[i][j]
            //if so, then display the dialogue then j++
            //else i++

    }

    public LinesManager(List<List<string>> Lines)
    {

        this.Lines = Lines;

    }
}
