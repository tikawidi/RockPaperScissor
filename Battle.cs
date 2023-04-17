using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    [SerializeField] State state;
    [SerializeField] GameObject battleResult;
    [SerializeField] TMP_Text battleResultText;
    [SerializeField] Player player1;
    [SerializeField] Player player2;

    // Temporary
    [SerializeField] bool isPlayerElemented;

    public enum State
    {
        Preparation,
        Player1Select,
        Player2Select,
        Attacking,
        Damaging,
        Returning,
        BattleISOver
    }

    void Update()
    {
        switch (state)
        {
            case State.Preparation:
                player1.Prepare();
                player2.Prepare();

                player1.SetPlay(true);
                player2.SetPlay(false);
                state = State.Player1Select;
                break;

            case State.Player1Select:
                if (player1.SelectedCharacter != null)
                {//set player 2 play next
                    player1.SetPlay(false);
                    player2.SetPlay(true);
                    state = State.Player2Select;
                }
                break;

            case State.Player2Select:
                if (player2.SelectedCharacter != null)
                {
                    player1.Attack();
                    player2.Attack();
                    state = State.Attacking;
                }
                break;

            case State.Attacking:
                if (player1.isAttacking() == false && player2.isAttacking() == false)
                {
                    CalculateBattle(player1, player2, out Player winner, out Player Loser);
                    if (Loser == null)
                    {
                        player1.TakeDamage(damageValue: player2.SelectedCharacter.AttackPower);
                        player1.TakeDamage(damageValue: player2.SelectedCharacter.AttackPower);
                    }
                    else
                    {
                        Loser.TakeDamage(winner.SelectedCharacter.AttackPower);
                    }

                    state = State.Damaging;
                }
                break;

            case State.Damaging:
                if (player1.IsDamaging() == false && player2.IsDamaging() == false)
                {
                    if (player1.SelectedCharacter.CurrentHp == 0)
                    {
                        player1.Remove(player1.SelectedCharacter);
                    }

                    if (player2.SelectedCharacter.CurrentHp == 0)
                    {
                        player2.Remove(player2.SelectedCharacter);
                    }

                    if (player1.SelectedCharacter != null)
                        player1.Return();

                    if (player2.SelectedCharacter != null)
                        player2.Return();

                    state = State.Returning;
                }
                break;

            case State.Returning:
                if (player1.IsReturning() == false && player2.IsReturning() == false)
                {
                    if (player1.CharacterList.Count == 0 && player2.CharacterList.Count == 0)
                    {
                        battleResult.SetActive(true);
                        battleResultText.text = "Battle Is Over!\nDraw";
                        state = State.BattleISOver;
                        //                            Debug.Log("Battle Is Over. Player1: " + player1.CharacterList.Count + " player2: " + player2.CharacterList.Count);
                    }
                    else if (player1.CharacterList.Count == 0)
                    {
                        battleResult.SetActive(true);
                        battleResultText.text = "Battle Is Over!\nPlayer 2 Win";
                        state = State.BattleISOver;
                    }
                    else if (player2.CharacterList.Count == 0)
                    {
                        battleResult.SetActive(true);
                        battleResultText.text = "Battle Is Over!\nPlayer 1 Win";
                        state = State.BattleISOver;
                    }
                    else
                    {
                        state = State.Preparation;
                    }
                }
                break;

            case State.BattleISOver:

                break;

            default:
                break;
        }
    }

    private void CalculateBattle(Player player1, Player player2, out Player winner, out Player Loser)
    {
        var type1 = player1.SelectedCharacter.Type;
        var type2 = player2.SelectedCharacter.Type;

        if (type1 == CharacterType.Batu && type2 == CharacterType.Kertas)
        {
            winner = player2;
            Loser = player1;
        }
        else if (type1 == CharacterType.Batu && type2 == CharacterType.Gunting)
        {
            winner = player1;
            Loser = player2;
        }
        else if (type1 == CharacterType.Gunting && type2 == CharacterType.Batu)
        {
            winner = player2;
            Loser = player1;
        }
        else if (type1 == CharacterType.Gunting && type2 == CharacterType.Kertas)
        {
            winner = player1;
            Loser = player2;
        }
        else if (type1 == CharacterType.Kertas && type2 == CharacterType.Batu)
        {
            winner = player1;
            Loser = player2;
        }
        else if (type1 == CharacterType.Kertas && type2 == CharacterType.Gunting)
        {
            winner = player2;
            Loser = player1;
        }
        else
        {
            winner = null;
            Loser = null;
        }
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Battle");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}