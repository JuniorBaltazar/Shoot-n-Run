using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.WeaponManager.ListWeapon;

namespace SO {

    namespace WeaponManager {

        #region Weapon
        /// <summary>
        /// Namespace adicionado apenas na "SOListWeapon".
        /// </summary>
        namespace ListWeapon {
            [System.Serializable]
            public class Weapon {

                [Tooltip("Nome da arma.")]
                public string weaponName;

                [Tooltip("Vá em Create -> Weapon -> Create Weapon.")]
                public SOWeapon weapon;
            }
        }
        #endregion

        [CreateAssetMenu(fileName = "ListWeapon", menuName = "Weapon/Weapons Manager/Create List Weapon", order = 2)]
        public class SOListWeapon : ScriptableObject {

            [Tooltip("Quantidade de armas(s).")]
            public List<Weapon> listWeapons = new List<Weapon>();
        }        
    }
}