using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullethole;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.P))
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Instantiate(bullethole, hitInfo.point - new Vector3(0f,0f,0.5f), Quaternion.identity);
            }//it is not instantiating the bullet hole center of screen instead it is getting instantiated bottom left corner of screen 
        }
    }
}
