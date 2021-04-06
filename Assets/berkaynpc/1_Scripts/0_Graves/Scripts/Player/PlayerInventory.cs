using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace project_WAST
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponHandlerManager weaponHandlerManager;
        PlayerManager playerManager;

        [Header("Spells")]
        public SpellItem currentSpell;
        public SpellItem rb_Spell;
        public SpellItem rt_Spell;

        [Header("All Spells")]
        public SpellItem[] rb_AllSpells = new SpellItem[1];
        public SpellItem[] rt_AllSpells = new SpellItem[1];

        [Header("Spell Switch Variables")]
        public int currentRBIndex = 0;
        public int currentRTIndex = 0;    

        [Header("Pickable Spells")]
        public List<SpellItem> spellsInventory;

        [Header("Requirement Keys")]
        public List<RequirementTypes.RequirementType> requirementList;
        public List<RequirementTypes.RequirementType> KeyList => requirementList;

        private void Awake()
        {
            weaponHandlerManager = GetComponentInChildren<WeaponHandlerManager>();
            playerManager = GetComponent<PlayerManager>();

            requirementList = new List<RequirementTypes.RequirementType>();
            requirementList.Add(RequirementTypes.RequirementType.nothing); //karakterin b�t�n butonlarla etkile�imi ii�in bla bla bu yaz�y� d�zelt 
        }

        private void Start()
        {
            currentRBIndex = 0;
            currentRTIndex = 0;
            currentSpell = rb_AllSpells[0];
            rb_Spell = rb_AllSpells[0];
            rt_Spell = rt_AllSpells[0];

            StartCoroutine("WaitForStart");
        }

        public void SwitchToNextWeapon(bool isLeft)
        {
            if(playerManager.inAnim)
            {
                return;
            }

            if (isLeft)
            {
                SwitchWeapons(ref rb_AllSpells, ref rb_Spell, true, ref currentRBIndex);
            }
            else
            {
                SwitchWeapons(ref rt_AllSpells, ref rt_Spell, false, ref currentRTIndex);
            }
        }

        private void SwitchWeapons(ref SpellItem[] currentWeaponsHand, ref SpellItem currentSpell, bool isRB_Spell, ref int currentHandIndex)
        {
            currentHandIndex++;

            if (currentHandIndex >= currentWeaponsHand.Length)
            {
                currentHandIndex = 0;
                /*currentSpell = unarmedSpell;
                weaponHandlerManager.LoadWeaponOnSlot(unarmedSpell, isRB_Spell);
                isUnarmed = true;*/                
            }

            if (currentWeaponsHand[currentHandIndex] != null)
            {
                //isUnarmed = false;
                currentSpell = currentWeaponsHand[currentHandIndex];
                weaponHandlerManager.LoadWeaponOnSlot(currentSpell, isRB_Spell);
            }

         
            /*
            if(currentSpell.spellIdle!=null)
            {
                animatorManager.animatorOverrideController["v4_Idle"] = currentSpell.spellIdle;             //sonra dusunulecek  
            }*/        
        }

        IEnumerator WaitForStart()
        {
            yield return new WaitForSeconds(0.5f);

            weaponHandlerManager.LoadWeaponOnSlot(rb_Spell, true);
            weaponHandlerManager.LoadWeaponOnSlot(rt_Spell, false);

            yield break;
        }



    }
}