using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO {

    namespace WeaponManager {

        [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Create Weapon", order = 1)]
        public class SOWeapon : ScriptableObject {

            [Tooltip("Vá em Create -> Weapon -> Create Bullet.")]
            public SOBullet bullet;

            [Tooltip("Quantidade de Bala(s).")]
            public byte bulletAmount;

            [Tooltip("Distância de respawn da(s) bala(s) no eixo z adicionada a posição do player.")]
            public float offsetPosZ = 1.5f;

            [Tooltip("Distância de respawn da(s) bala(s) no eixo z adicionada a posição do player.")]
            public AudioEvent bulletSfx;
        }        
    }
}