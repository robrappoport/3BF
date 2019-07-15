using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo
{
    public string cname;
    public List<List<string>> curLines = new List<List<string>>();
    public GameObject curCostume;
    public GameObject curSpawn;
    public List<ScheduleItem> schedule = new List<ScheduleItem>();
    // Start is called before the first frame update
    public CharacterInfo(string name, List<ScheduleItem> schedule, GameObject costume, GameObject spawnPoint)
    {
        cname = name;
        this.schedule = schedule;
        this.curCostume = costume;
        this.curSpawn = spawnPoint;
 
    }

    public bool TalksHere(int day, int time, string location)
    {
        for (int i = 0; i < schedule.Count; i++)
        {
            if (schedule[i].day == day && schedule[i].time == time && schedule[i].location == location)
            {
                curLines = schedule[i].dialogue;
                curCostume = schedule[i].costume;
                curSpawn = schedule[i].spawnPoint;
                return true;
            }
        }
        return false;
    }
}
