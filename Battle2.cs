using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle2 : MonoBehaviour
{
    [SerializeField] State state;
    //[SerializeField] Player player1;
    //[SerializeField] Player player2;
    public enum State
    {
        Preparation,
        Player1Select,
        Player2Select,
        Attacking,
        Damaging,
        Returning,
        BattleOver
    }
    void Update()
    {
        switch (state)
        {
            case State.Preparation:
                break;
            case State.Player1Select:
                break;
            case State.Player2Select:
                break;
            case State.Attacking:
              
                break;
            case State.Damaging:
                break;
            case State.Returning:
                break;
            case State.BattleOver:
                break;
            default:
                break;
        }
        
    }
}