using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePeriod : MonoBehaviour
{
    public int curDay; //Important
    public int totalDay;
    public int curTime; //Important
    public int maxTime;
    public string curLocation; //Important
    public GameObject farmSpawn;
    public GameObject townSpawn;

    public GameObject SpawnPoint()
    {
        if (curLocation == "Farm")
        {
            return farmSpawn;
        }

        else if (curLocation == "Town")
        {
            return townSpawn;
        }
        else
            return

                null;

    }

}
