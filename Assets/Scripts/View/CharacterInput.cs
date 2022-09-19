using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    private Camera cameraMain;
    [HideInInspector] public LayerMask Mask;

    private void Awake()
    {
        cameraMain = Camera.main;
    }
    
    public Vector3 GetDestinationPoint()
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, Mask))
            {
                if (hit.collider.CompareTag("Resep"))
                {
                    return hit.collider.GetComponentInChildren<Transform>().position;
                }
                else
                {
                    var direction = (hit.point - transform.position).normalized;
                
                    var lookRotation = Quaternion.LookRotation(direction);
                
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 500);

                    return hit.point;
                }
            }
            else
            {
                return transform.position;
            }
        
    }
}
