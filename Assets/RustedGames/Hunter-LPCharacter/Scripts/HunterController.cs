using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RustedGames
{   
    public class HunterController : MonoBehaviour
    {

        [SerializeField]
        private List<ArmorSet> armors = new List<ArmorSet>();

        [SerializeField]
        private Animator hunterAnimator;

        [SerializeField]
        private Animator cleaverAnimator;


        public void EquipArmor(int armorId)
        {
            if (armors.Count >= armorId)
            {
                armors[armorId].EquipArmorSet();
            }
        }


        public void PlayClip  (string stateName)
        {           
            hunterAnimator.CrossFade(stateName, 0.05f);
        }

        public void OpenCleaver()
        {
            cleaverAnimator.SetBool("Open", true);
            cleaverAnimator.SetBool("Close", false);
        }

        public void CloseCleaver()
        {
            cleaverAnimator.SetBool("Open", false);
            cleaverAnimator.SetBool("Close", true);
        }
       
    }

    [System.Serializable]
    public class ArmorSet
    {
        public string name;

        public List<GameObject> armorParts = new List<GameObject>();
        public List<GameObject> hiddenParts = new List<GameObject>(); 
        private void HideParts()
        {
            foreach (GameObject part in hiddenParts)
            {
                part.SetActive(false);
            }
        }

        public void EquipArmorSet()
        {
            HideParts();

            foreach (GameObject armor in armorParts)
            {
                armor.SetActive(true);
            }            
        }
    }
}