using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpItem: MonoBehaviour
{
    [SerializeField]string name;
    [SerializeField] bool used;
    [SerializeField] EPowerUpType type;


    public PowerUpItem(string name, EPowerUpType type)
    {
        this.name = name;
        this.used = false;
        this.type = type;
    }

    public string Name { get => name; }
    public bool Used { get => used; set => used = value; }
    public EPowerUpType Type { get => type; }
    public int Points
    {
        get
        {
            int points = 0;

            if (!Used)
                points += (int)Type * 2;
            else
                points = (int)Type;

            return points;
        }
    }
}