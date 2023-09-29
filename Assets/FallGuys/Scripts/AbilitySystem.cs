using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    public Ability Ability;
    float cooldownTime;
 


    enum AbilityState
    {
        active,
        coolDown
    }
    [SerializeField]
    KeyCode key;
    AbilityState state = AbilityState.active;

    private void Update()
    {
        Debug.Log(cooldownTime);
        switch(state)
        {
            case AbilityState.active:
                if (Input.GetKeyDown(key))
                {
                    if (Ability.Use(gameObject)){
                        state = AbilityState.coolDown;
                        cooldownTime = Ability.CoolDownTime;
                    }
    
                }
                break;
            case AbilityState.coolDown:
                if (cooldownTime>0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.active;
                }

                break;
        }

    }

}
