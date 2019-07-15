using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleItem
{
    public string location;
    public int day;
    public int time;
    public GameObject costume;
    public GameObject spawnPoint;
    public List<List<string>> dialogue = new List<List<string>>();
    public ScheduleItem(int day, int time, string location, List<List<string>> dialogue, GameObject costume, GameObject spawnPoint)
    {
        this.location = location;
        this.dialogue = dialogue;
        this.time = time;
        this.day = day;
        this.costume = costume;
        this.spawnPoint = spawnPoint;
    }
}
