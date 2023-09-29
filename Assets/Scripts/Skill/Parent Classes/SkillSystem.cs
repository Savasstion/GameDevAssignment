using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    [SerializeField]
    private bool aoeCursorState;
    [SerializeField]
    private bool aoeCastState;
    [SerializeField]
    private int skillSlot;
    [SerializeField]
    private static int maxSkillEquipNum = 3;
    [SerializeField]
    public List<Skill> equippedSkills;
    [SerializeField]
    private GrenadeSkill grenade;

    private void Start()
    {
        equippedSkills.Add(grenade);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 Pressed");
            equippedSkills[0].CastSkill();
        }
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //    equippedSkills[1].CastSkill();
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //    equippedSkills[2].CastSkill();
        //else if (Input.GetKeyDown(KeyCode.Alpha4))
        //    equippedSkills[3].CastSkill();
        //else if (Input.GetKeyDown(KeyCode.Alpha5))
        //    equippedSkills[4].CastSkill();
    }

    public void equipSkill(Skill skill)
    {
        for (int i = 0; i < maxSkillEquipNum; i++)
            if (equippedSkills[i] == null)
                equippedSkills[i] = skill;
            else if (equippedSkills[i] != null && i == (maxSkillEquipNum - 1))
            {
                Debug.Log("No available skill equip slot!");
            }



    }

    public void unequipSkill(int option)
    {
        if (equippedSkills[option - 1] != null)
        {
            equippedSkills.RemoveAt(option - 1);
            Debug.Log("Unequipped skill");
        }
    }

}