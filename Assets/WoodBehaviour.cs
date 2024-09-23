using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBehaviour : Placeable
{
    private void Start()
    {
        base.Initialize();

    }

    //hacer que  de madera (recurso para goap)
    public int gather()
    {
        return 1;
    }

}
