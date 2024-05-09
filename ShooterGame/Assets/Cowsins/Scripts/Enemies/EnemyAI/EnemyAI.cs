using UnityEngine;
namespace cowsins
{
    public class EnemyAI : EnemyHealth
    {
        public BoxCollider mainCollider;
        public BoxCollider headCollider;
        public GameObject enemyRig;
        public Animator enemyAnimator;
        public Rigidbody mainRigidbody;

        Collider[] ragDollColliders;
        Rigidbody[] ragDollBodies;

        public MonoBehaviour enemyShootScript;

        public void RagdollOn()
        {
            ragDollColliders = enemyRig.GetComponentsInChildren<Collider>();
            ragDollBodies = enemyRig.GetComponentsInChildren<Rigidbody>();

            foreach (Collider col in ragDollColliders)
            {
                col.enabled = true;
            }

            foreach (Rigidbody rigid in ragDollBodies)
            {
                rigid.isKinematic = false;
            }

            mainCollider.enabled = false;
            headCollider.enabled = false;
            enemyAnimator.enabled = false;
            mainRigidbody.isKinematic = true;

            enemyShootScript.enabled = false;
        }

        float takenDamage = 0;

        public override void Damage(float damage)
        {
            takenDamage += damage;

            if (takenDamage >= 15)
            {
                RagdollOn();
            }
        }
    }
}