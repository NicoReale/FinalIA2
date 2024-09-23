using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldState : MonoBehaviour
{
    public bool has_fire;

    public static WorldState instance;



    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }
}
