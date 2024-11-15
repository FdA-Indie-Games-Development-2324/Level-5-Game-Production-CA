using UnityEngine;

public class OverlapSphereTest : MonoBehaviour
{

    // Update is called once per frame
    public void Update()
    {
        Debug.Log("asdokasdom");
        Collider[] col = Physics.OverlapSphere(transform.position, 1);
        
        if(col.Length > 1){
            Debug.Log("Too many colliders");
        }else{
            Debug.Log("Can place");
        }
    }

    void OnDrawGizmos(){
        Gizmos.DrawSphere(transform.position, 1);
    }
}
