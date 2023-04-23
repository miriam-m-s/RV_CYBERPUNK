using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Sword : MonoBehaviour
{

    [SerializeField]
    CutMultiplePartsConcave cutter;

    [SerializeField]
    LayerMask sliceableLayerMask;

    public void ObjectSlashed(OnTriggerDelegation delegation)
    {
        // Si no es un objecto cortable, ignorarlo
        if (delegation.Other.gameObject.layer != 8)
            return;

        // Objeto que se ha atravesado
        GameObject slicedObj = delegation.Other.gameObject;
        // Asignarle al cutter el objeto Mesh, padre del collider
        cutter.SetTarget(slicedObj.transform.parent.gameObject);

        // Cortar el objeto atravesado
        cutter.Cut();

        // Destruir el collider asignado al objeto cortado
        Destroy(slicedObj);
    }

    public void ObjectHitted(OnTriggerDelegation delegation)
    {
        // Si no es un objecto cortable, ignorarlo
        if (delegation.Other.gameObject.layer != 7)
            return;

        // Objeto que se ha atravesado
        GameObject gObj = delegation.Other.gameObject;

        gObj.GetComponentInParent<RagdollController>().SetEnableRagdoll(true);
    }
}
