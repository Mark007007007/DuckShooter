using UnityEngine;
using UnityEngine.InputSystem;

public class PointerScript : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] GameObject _cube;
    Vector2 mousePos;
    Ray rayOrigin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Mouse.current.position.ReadValue();
            rayOrigin = Camera.main.ScreenPointToRay(mousePos);
            //Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _player.Movement(hitInfo.point);
                Debug.Log(hitInfo.point);
                //Instantiate(_cube, new Vector3((int)hitInfo.point.x, (int)hitInfo.point.y ,(int)hitInfo.point.z), Quaternion.identity);
            }
        }
    }
}
