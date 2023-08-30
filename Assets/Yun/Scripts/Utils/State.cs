using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<TOwner> where TOwner : class
{
    public abstract void Enter(TOwner owner);
    public abstract void Update(TOwner owner);
    public abstract void Exit(TOwner owner);
}
