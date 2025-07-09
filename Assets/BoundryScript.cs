using Unity.VisualScripting;
using UnityEngine;

public class BoundryScript : MonoBehaviour
{
   private void OnTriggerExit(Collider other)
   {
      Destroy(other.gameObject); // Destroy the object that exits the boundary
   }
}
