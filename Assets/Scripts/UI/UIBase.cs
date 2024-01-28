using UnityEngine;

namespace UI
{
    public class UIBase : MonoBehaviour
    {
        public void Show() => 
            gameObject.SetActive(true);
        
        public void Hide() => 
            gameObject.SetActive(false);
    }
}