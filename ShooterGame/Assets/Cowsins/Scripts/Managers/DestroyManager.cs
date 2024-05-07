using UnityEngine;
namespace cowsins
{
    public class DestroyManager : EnemyHealth
    {
        public MonoBehaviour fractureScript;

        public override void Damage(float damage)
        {
            fractureScript.enabled = true;
        }
    }
}