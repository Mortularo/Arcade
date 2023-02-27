using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gunship
{
    [AddComponentMenu("Pool/ObjectPooling")]
    public class BulletPooling
    {
        #region Data
        List<PoolObject> objects;
        Transform objectsParent;
        #endregion
        private void AddBullet(PoolObject sample, Transform objectsParent)
        {
            GameObject temp = GameObject.Instantiate(sample.gameObject);
            temp.name = sample.name;
            temp.transform.SetParent(objectsParent);
            objects.Add(temp.GetComponent<PoolObject>());
            if (temp.GetComponent<Animator>())
            {
                temp.GetComponent<Animator>().StartPlayback();
            }
            temp.SetActive(false);
        }
        public void Initialize(int count, PoolObject sample, Transform objects_parent)
        {
            objects = new List<PoolObject>(); //инициализируем List
            objectsParent = objects_parent; //инициализируем локальную переменную для последующего использования
            for (int i = 0; i < count; i++)
            {
                AddBullet(sample, objects_parent); //создаем объекты до указанного количества
            }
        }
        public PoolObject GetBullet()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].gameObject.activeInHierarchy == false)
                {
                    return objects[i];
                }
            }
            AddBullet(objects[0], objectsParent);
            return objects[objects.Count - 1];
        }

    }
}