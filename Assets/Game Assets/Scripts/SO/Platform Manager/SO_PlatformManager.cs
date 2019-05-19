using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO {

    namespace PlatformManager {

        [CreateAssetMenu(fileName = "ListWeapon", menuName = "Platform/Create Platform Manager", order = 0)]
        public class SO_PlatformManager : ScriptableObject {

            public List<GameObject> platformPrefabList = new List<GameObject>();
        }
    }
}