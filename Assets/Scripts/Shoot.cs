using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    private UIManager _uIManager;
    void Start()
    {
        _uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    void Update()
    {
      
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo, 100.0f, 1 << 6))
            {
                Debug.Log(hitInfo.collider.name);
                if (hitInfo.collider.tag == "Enemy")
                {
                    hitInfo.collider.transform.GetComponent<AI>().SetAIStateToDeath();
                }
                else if (hitInfo.collider.tag == "Barrier")
                {
                    hitInfo.collider.transform.GetComponent<Barrier>().TakeDamage();
                }
            }
            _uIManager.UpdateAmmoText();
        }
    }
}
