using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    void Update()
    {
      
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.collider.transform.GetComponent<AI>() != null)
                {
                    hitInfo.collider.transform.GetComponent<AI>().SetAIStateToDeath();
                }
            }
        }
    }
}
