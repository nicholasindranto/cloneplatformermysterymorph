using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    // singletonnya
    public static GoalManager singleton;
    // berapa holy water buat open door nya sama berapa buat collectednya
    public int holyWaterNeeded, holyWaterCollected;
    // bisa masuk pa gak
    public bool canEnter;

    private void Awake()
    {
        singleton = this;
    }

    public void CollectHolyWater()
    {
        holyWaterCollected++;
        if (holyWaterCollected >= holyWaterNeeded)
        {
            canEnter = true;
        }
    }
}
