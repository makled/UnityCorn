using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitycorn
{
    [CreateAssetMenu (fileName ="New Bullet", menuName = "Unitycorn/Bullet", order = 0) ]
    public class Bullet : ScriptableObject
    {
        // Start is called before the first frame update
        [Tooltip ("Bullet Name")]
        [SerializeField]
        private string BulletName;

        [Tooltip ("Bullet Damage")]
        [SerializeField]
        public float BulletDamage;

        [Tooltip ("Bullet Energy Consumption")]
        [SerializeField]
        public float BulletEnergyConsumption;
    }
}

