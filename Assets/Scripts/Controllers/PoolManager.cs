using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

namespace Gunship
{
    public static class PoolManager
    {
        private static PoolPart[] pools;
        private static GameObject objectsParent;
        [System.Serializable]
        public struct PoolPart
        {
            public string name; // Имя префаба
            public PoolObject prefab; // Префаб
            public int count; // Число объектов при инициализации пула
            public BulletPooling ammo;
        }
        public static void Initialize(PoolPart[] newPools)
        {
            pools = newPools;
            objectsParent = new GameObject();
            objectsParent.name = "Ammo";
            for (int i = 0; i < pools.Length; i++)
            {
                if(pools[i].prefab != null)
                {
                    pools[i].ammo = new BulletPooling(); // Отдельный пул для каждого префаба
                    pools[i].ammo.Initialize(pools[i].count, pools[i].prefab, objectsParent.transform);
                } 
            }
        }
        public static GameObject GetObject(string name, Vector2 position, Quaternion rotation)
        {
            GameObject result = null;
            if (pools != null)
            {
                for (int i=0; i < pools.Length; i++)
                {
                    if (string.Compare(pools[i].name, name) == 0)
                    {
                        result = pools[i].ammo.GetBullet().gameObject;
                        result.transform.position = position;
                        result.transform.rotation = rotation;
                        result.SetActive(true);
                        return result;
                    }
                }
            }
            return result;
        }
    }
}