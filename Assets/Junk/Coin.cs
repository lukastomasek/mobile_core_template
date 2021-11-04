using UnityEngine;
using Mobile_Core;

namespace Mobile_Test
{
    public class Coin : MonoBehaviour
    {
        ParticleSystem _particle;

        private void Awake()
        {
            _particle = GetComponentInChildren<ParticleSystem>();
        }

        private void OnTriggerEnter(Collider item)
        {
            if (item.CompareTag(TagManager.PLAYER))
            {
                _particle.Play();
                Destroy(gameObject, 2);

            }
        }

    }

}