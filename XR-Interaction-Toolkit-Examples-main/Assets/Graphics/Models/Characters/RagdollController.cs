using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    Rigidbody[] allRb;

    void Start()
    {
        allRb = GetComponentsInChildren<Rigidbody>();
        SetEnableRagdoll(false);
    }

    public void SetEnableRagdoll(bool enabled)
    {
        bool kinematic = !enabled;
        foreach (Rigidbody rb in allRb)
            rb.isKinematic = kinematic;

        anim.enabled = !enabled;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SetEnableRagdoll(true);

        if (Input.GetKeyDown(KeyCode.T))
            SetEnableRagdoll(false);
    }
}
