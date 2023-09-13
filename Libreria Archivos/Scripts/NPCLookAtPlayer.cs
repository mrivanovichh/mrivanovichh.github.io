
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.Animations;
using System.Collections.Generic;

public class NPCLookAtPlayer : UdonSharpBehaviour
{
   /* public Transform npcHead; // Assign the NPC's head GameObject in the Inspector

    private AimConstraint aimConstraint;

    private void Start()
    {
        aimConstraint = npcHead.GetComponent<AimConstraint>();
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        Vector3 playerHeadPosition = player.GetBonePosition(HumanBodyBones.Head);
        aimConstraint.SetSource(0, new ConstraintSource
        {
            sourceTransform = null, // Set to null to use position-based constraint
            weight = 1.0f,
            constraintActive = true,
            sourceOffset = playerHeadPosition
        });
    }*/

}
