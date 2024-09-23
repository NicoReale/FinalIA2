using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else instance = this;

    }

    private void Update()
    {

    }
}
