using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour
{
    public static GameManager _instance;
    public GameObject characterObj;
    public GameObject playerObj;
    public GameObject player;
    public static GameManager Instance { get { return _instance; } }

    public List<CharacterInfo> castList = new List<CharacterInfo>();
    public List<GameObject> costumes = new List<GameObject>();
    public List<GameObject> mayaSpawnPoints = new List<GameObject>();
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        CreateCharacters();
    }
    public TimePeriod timePeriod;
    private bool timePassing;

    private void Start()
    {
        timePeriod = GetComponent<TimePeriod>();
        // check day, time, location
        // load appropriate characters for the day, time, location
        // load into characters the appropriate dialogue JSON files


        int day = timePeriod.curDay;
        int time = timePeriod.curTime;
        string loc = timePeriod.curLocation;

        player = Instantiate(playerObj);
        player.transform.position = timePeriod.SpawnPoint().transform.position;
        this.GetComponent<ClickManager>().player = player;
        List<CharacterInfo> charInScene = new List<CharacterInfo>();
        foreach (CharacterInfo curChar in castList)
        {
            if (curChar.TalksHere(day, time, loc))
            {
                charInScene.Add(curChar);

                GameObject newCharacter = Instantiate(characterObj);
                newCharacter.transform.position = curChar.curSpawn.transform.position;
                newCharacter.GetComponent<Character>().cname = curChar.cname;
                newCharacter.GetComponent<Character>().curLines = curChar.curLines;
                GameObject charCostume = Instantiate(newCharacter.GetComponent<Character>().costume = curChar.curCostume);
                charCostume.transform.SetParent(newCharacter.transform);
                charCostume.transform.localPosition = Vector3.zero;
                
                charCostume.name = "Costume";
                newCharacter.name = curChar.cname;
                
            }
        }

        

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var foundCharacter = FindObjectOfType<Character>();
            Debug.Log(foundCharacter.curLines[0][0]);
        //    if (!timePassing)
        //    {
        //        timePassing = true;
        //    }
        //    else
        //    {
        //        timePassing = false;
        //    }
        //}
        //if (timePassing)
        //{
        //    if (timePeriod.curDay <= timePeriod.totalDay)
        //    {
        //        TimePasses();
        //    }
        }
    }

    void TimePasses()
    {
        float fTime = Time.deltaTime;
        int iTime = (int)fTime;
        timePeriod.curTime += iTime;

        if (timePeriod.curTime > timePeriod.maxTime)
        {
            timePeriod.curTime = 0;
            timePeriod.curDay++;
        }
    }


    void CreateCharacters()
    {
        GameObject MayaCostume = costumes[0];
        GameObject spawnPoint1 = mayaSpawnPoints[0];
        GameObject spawnPoint2 = mayaSpawnPoints[1];
        List<List<string>> DialogueListA = new List<List<string>>();
        DialogueListA.Add(new List<string> { "hello", "how are you?" });

        castList.Add (new CharacterInfo("Maya", new List<ScheduleItem>()
        {
            new ScheduleItem(0,0,"Farm",DialogueListA, MayaCostume, spawnPoint1),
            new ScheduleItem(0,1,"Town",DialogueListA, MayaCostume, spawnPoint2),
            new ScheduleItem(0,2,"Farm",DialogueListA, MayaCostume, spawnPoint1),
            new ScheduleItem(1,0,"Farm",DialogueListA, MayaCostume, spawnPoint2),
            new ScheduleItem(1,1,"Farm",DialogueListA, MayaCostume, spawnPoint1),
            new ScheduleItem(1,2,"Farm",DialogueListA, MayaCostume, spawnPoint2),
            new ScheduleItem(2,0,"Farm",DialogueListA, MayaCostume, spawnPoint1),
            new ScheduleItem(2,1,"Farm",DialogueListA, MayaCostume, spawnPoint2),
            new ScheduleItem(2,2,"Farm",DialogueListA, MayaCostume, spawnPoint1),
            new ScheduleItem(3,0,"Farm",DialogueListA, MayaCostume, spawnPoint2),
            new ScheduleItem(3,1,"Farm",DialogueListA, MayaCostume, spawnPoint1),
            new ScheduleItem(3,2,"Farm",DialogueListA, MayaCostume, spawnPoint2),
            new ScheduleItem(4,0,"Farm",DialogueListA, MayaCostume, spawnPoint1),
            new ScheduleItem(4,1,"Farm",DialogueListA, MayaCostume, spawnPoint2),
            new ScheduleItem(4,2,"Farm",DialogueListA, MayaCostume, spawnPoint1),
            new ScheduleItem(5,0,"Farm",DialogueListA, MayaCostume, spawnPoint2),
            new ScheduleItem(5,1,"Farm",DialogueListA, MayaCostume, spawnPoint1),
            new ScheduleItem(5,2,"Farm",DialogueListA, MayaCostume, spawnPoint2),
            new ScheduleItem(6,0,"Farm",DialogueListA, MayaCostume, spawnPoint1),
            new ScheduleItem(6,1,"Farm",DialogueListA, MayaCostume, spawnPoint2),
            new ScheduleItem(6,2,"Farm",DialogueListA, MayaCostume, spawnPoint1)
        }, null, null));
    }


}
