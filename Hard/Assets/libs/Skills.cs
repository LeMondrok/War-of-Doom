using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using System.Collections;


namespace Skills
{
    public enum SkillType { TargetedAlly = 1, TargetedEnemy, SelfSkill, NonTargeted }

    public abstract class skills : MonoBehaviour
    {
        SkillType skillType;
        public int cooldown;

        public skills(SkillType skillType_, int cooldown_)
        {
            cooldown = cooldown_;

            skillType = skillType_;
        }

        abstract public void use(Entity target_, Entity caster_);
    }

    public class heal : skills
    {
        bool cool = true;
        int power, manaCost;
        public GameObject healEffect;

        public heal (SkillType skillType_, int cooldown_, int power_, int manaCost_)
            :base(skillType_, cooldown_)
        {
            power = power_;
            manaCost = manaCost_;

            healEffect = GameObject.Find("rainbow");
        }

        override public void use(Entity target, Entity caster)
        {
            if (caster.getMana() > manaCost)
            {


                caster.changeMana(-manaCost);
                target.changeHealth(power);

                Instantiate(healEffect, caster.transform);

                //StartCoroutine("Cooldown");
            }
            else
            {
                Debug.Log("asdasd");
            }
        }

        IEnumerator Cooldown()
        {
            cool = false;

            yield return new WaitForSeconds(cooldown);

            cool = true;
        }
    }
}
