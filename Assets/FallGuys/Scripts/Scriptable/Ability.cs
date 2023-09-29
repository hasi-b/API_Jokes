using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string AbilityName;
    public string AbilityDescription;
    public float CoolDownTime;

    public abstract bool Use(GameObject player);
}
