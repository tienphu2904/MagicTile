using UnityEngine;

namespace UI
{
    public class BackGroundEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particleSystemList;

        private void Awake()
        {
            ClearEffect();
        }

        public void PlayEffect()
        {
            foreach (var obj in particleSystemList)        
            {
                obj.Play();
            }
        }
    
        public void ClearEffect()
        {
            foreach (var obj in particleSystemList)        
            {
                obj.Clear();
                obj.Pause();
            }
        }
    }
}
