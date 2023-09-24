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
    public List<Skill> equippedSkills = new List<Skill>();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            equippedSkills[0].castSkill();
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            equippedSkills[1].castSkill();
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            equippedSkills[2].castSkill();
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            equippedSkills[3].castSkill();
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            equippedSkills[4].castSkill();
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