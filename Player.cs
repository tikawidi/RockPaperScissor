//using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] Character selectedCharacter;
    [SerializeField] List<Character> characterList;
    [SerializeField] Transform AtkEfk;
    [SerializeField] bool isBot;

    public Character SelectedCharacter { get => selectedCharacter; }
    public List<Character> CharacterList { get => characterList; }

    private void Start()
    {
        if (isBot){
         foreach (var character in characterList)
            {
                character.Button.interactable = false;
            } 
        }
    }

    public void Prepare()
    {
        selectedCharacter = null;
    }

    public void SelectCharacter(Character character)
    {
        selectedCharacter = character;
    }

    public void SetPlay(bool value)
    {
        if (isBot)
        {
            int index = Random.Range(0,characterList.Count);
            selectedCharacter = characterList[index];
        }
        else
        {
            foreach (var character in characterList)
            {
                character.Button.interactable = value;
            } 
        }
        
    }
 
    public void Attack()
    {
        selectedCharacter.transform.DOMove(AtkEfk.position, 1f, true).SetEase(Ease.Linear);
    }

    public bool isAttacking()
    {
        if(selectedCharacter == null)
            return false;
        return DOTween.IsTweening(selectedCharacter.transform);
    }

    public void TakeDamage(int damageValue)
    {
        selectedCharacter.ChangeHP(-damageValue);
        var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
        spriteRend.DOColor(Color.red, 1f).SetLoops(3);
    }

    public bool IsDamaging()
    {
        if(selectedCharacter == null)
            return false;
        var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
        return DOTween.IsTweening(spriteRend);
    }

    public void Remove(Character Character)
    {
        if(characterList.Contains(Character) == false )
            return;
       
        if (selectedCharacter == Character)
            selectedCharacter = null;
        Character.Button.interactable = false;
        Character.gameObject.SetActive(false);
        characterList.Remove(Character);
    }
    public void Return()
    {
        selectedCharacter.transform.DOMove(selectedCharacter.InitialPosition, 1f);

    }

    public bool IsReturning()
    {
        if(selectedCharacter == null)
            return false;
        return DOTween.IsTweening(selectedCharacter.transform);
    }
}
    

