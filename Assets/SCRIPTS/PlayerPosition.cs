using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerPosition
{
    public float x;
    public float y;
    public float z;
    public string username;
    public string userId;

    public PlayerPosition(float x, float y,float z, string username, string userId)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.username = username;
        this.userId = userId;
    }
}
