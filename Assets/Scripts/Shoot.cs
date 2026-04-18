using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    private UIManager _uIManager;
    private AudioManager _audioManager;
    void Start()
    {
        _uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    void Update()
    {
      
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _audioManager.PlayShootSound();
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo, 100.0f, 1 << 6))
            {
                if (hitInfo.collider.tag == "Enemy")
                {
                    hitInfo.collider.transform.GetComponent<AI>().SetAIStateToDeath();
                }
                else if (hitInfo.collider.tag == "Barrier")
                {
                    _audioManager.PlayShotBarrierSound();
                    hitInfo.collider.transform.GetComponent<Barrier>().TakeDamage();
                }
            }
            _uIManager.UpdateAmmoText();
        }
    }
}
