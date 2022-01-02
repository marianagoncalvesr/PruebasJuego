using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys
{
    private int lvl;
    private bool usedInDoor;
    private bool picked;

    public Keys()
    {
        lvl = 0;
        usedInDoor = false;
    }

    public int Lvl { get => lvl; }
    public bool UsedInDoor { get => usedInDoor; set => usedInDoor = value; }
    public bool Picked { get => picked; set => picked = value; }
}