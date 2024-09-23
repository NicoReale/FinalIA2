using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceBehaviour : Placeable
{
    public float fuel = 100;

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
    }

    private void Update()
    {
        if(isActive)
            fuel -= Time.deltaTime * 3;
    }

    private void OnEnable()
    {
        isActive = true;
    }
    private void OnDisable()
    {
        isActive = false;
    }

}
