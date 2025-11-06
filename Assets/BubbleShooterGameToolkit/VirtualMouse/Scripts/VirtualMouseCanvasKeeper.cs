
 










using UnityEngine;

namespace VirtualMouse.Scripts
{
    public class VirtualMouseCanvasKeeper : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}