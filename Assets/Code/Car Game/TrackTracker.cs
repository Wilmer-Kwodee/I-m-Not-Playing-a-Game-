using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTracker : MonoBehaviour
{
    public static string[] pattern = new string[3];

    // YEEE THESE ENTIRE THING BELOW IS USELESS, EXCEPT THIS ARRAY ABOVE ^^

    void Start()
    {

    }
    void Update()
    {
        //cekpattern();
        //report();
    }

    private void report()
    {
        Debug.Log(pattern[0] + pattern[1] + pattern[2]);
        Invoke("report", 1);
    }
    private void cekpattern()
    {
        if (pattern[0] == "straight" && pattern[1] == "right" && pattern[2] == "right")
        {
            if (RoadGenerator.undian == 3)
            {
                int undianbaru = Random.Range(1, 3);
                RoadGenerator.undian = undianbaru;
            }
        }
        if (pattern[0] == "straight" && pattern[1] == "left" && pattern[2] == "left")
        {
            if (RoadGenerator.undian == 2)
            {
                int undianbaru = Random.Range(0, 2);
                if (undianbaru == 0)
                {
                    undianbaru = 1;
                }
                else
                    undianbaru = 3;
                RoadGenerator.undian = undianbaru;
            }
        }
        if (pattern[0] == "left" && pattern[1] == "left" && pattern[2] == "left")
        {
            if (RoadGenerator.undian == 2)
            {
                RoadGenerator.undian = 3;
            }
        }
        if (pattern[0] == "right" && pattern[1] == "right" && pattern[2] == "right")
        {
            RoadGenerator.undian = 2;
        }
    }
}
