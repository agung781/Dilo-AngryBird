using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBird : Bird
{

    public float fieldimpact;
    public float force;
    public LayerMask layertohit;
    public bool _hasexploade = false;

    public void explode()
    {
        if (State == BirdState.Thrown && !_hasexploade)
        {
            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldimpact, layertohit);

            foreach (Collider2D obj in objects)
            {
                Vector2 direction = obj.transform.position - transform.position;

                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }
            _hasexploade = true;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, fieldimpact);
    }

    public override void OnTap()
    {
        explode();
    }
}
