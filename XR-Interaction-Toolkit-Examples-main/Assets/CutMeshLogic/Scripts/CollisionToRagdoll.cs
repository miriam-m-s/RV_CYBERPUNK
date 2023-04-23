using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToRagdoll : MonoBehaviour
{
    [SerializeField]
    Transform centerOfForce;

    private void OnCollisionEnter(Collision collision)
    {
        // Si no es un objecto cortable, ignorarlo
        if (collision.gameObject.layer != 7)
            return;

        // Objeto que se ha atravesado
        GameObject gObj = collision.gameObject;

        gObj.GetComponentInParent<RagdollController>().SetEnableRagdoll(true);

        Vector3 hitDirection = gObj.transform.position - centerOfForce.transform.position;
        hitDirection.Normalize();
        gObj.GetComponentInParent<Rigidbody>().AddForce(hitDirection * 100, ForceMode.Impulse);
    }
}
