﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO {

    namespace WeaponManager {

        [CreateAssetMenu(fileName = "Bullet", menuName = "Weapon/Create Bullet", order = 0)]
        public class SOBullet : ScriptableObject {

            [Tooltip("Prefab da Bala.")]
            public GameObject prefab;

            [Tooltip("Se tiver um MeshRenderer, pode-se mudar a cor do material.")]
            public Color materialColor = Color.white;

            [Tooltip("Velocidade da Bala.")]
            public ushort speed = 20;

            [Tooltip("Tempo para desativar a bala após ativada.")]
            public float cooldownDesactive = 1;

            [Tooltip("Tipo de obstáculo que a bala destrói.")]
            public string destructibleObjName = "";
        }
    }
}