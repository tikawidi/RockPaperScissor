using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Character : MonoBehaviour
{
    
    [SerializeField] new string name;
    [SerializeField] CharacterType type;
    [SerializeField] int currentHp;
    [SerializeField] int maxHP;
    [SerializeField] int attackPower;
    //[SerializeField] TMP_Text overHeadText;
    [SerializeField] Image avatar;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text typeText;
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text hpText;
    [SerializeField] Button button;

    private Vector3 initialPosition;

    public Button Button { get => button;}
    public CharacterType Type { get => type;}
    public int AttackPower { get => attackPower;}
    public int CurrentHp {get => currentHp;}
    public Vector3 InitialPosition { get => initialPosition;}

    private void Start() 
    {
        initialPosition = this.transform.position;
        nameText.text = name;
        button.interactable = false;
        UpdateHPUI();
    }
    public void ChangeHP(int amount)
    {
        currentHp += amount;
        // if (currentHp < 0)
        // {
        //     currentHp = 0;
        // }
        // if (currentHp > maxHP)
        // {
        //     currentHp = maxHP;
        // }
        currentHp = Mathf.Clamp(currentHp,0, maxHP);
        UpdateHPUI();
    }
     private void UpdateHPUI() 
     {
        healthBar.fillAmount = (float)currentHp / (float)maxHP;
        hpText.text = currentHp + "/" + maxHP;
        
    }

}
