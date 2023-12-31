using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{

    public Transform playerCameraTransform;
    public Transform objectGrabPointTransform;
    public LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;

    public void PickUpOrDrop(CharacterController controller)
    {
        if (objectGrabbable == null)
        {
            // Not carrying an object, try to grab
            float pickUpDistance = 5f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                {
                    objectGrabbable.Grab(objectGrabPointTransform);
                }
            }
        }
        else
        {
            // Currently carrying something, drop
            objectGrabbable.Drop();
            objectGrabbable = null;
        }
    }
}
