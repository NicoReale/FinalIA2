using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public string Name { get; set; }
    public void Enter();
    public void Execute();
    public void Exit();
}
