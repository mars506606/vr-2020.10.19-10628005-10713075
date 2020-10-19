using UnityEngine;

namespace KID
{
    [RequireComponent(typeof(AudioSource))]
    public class Explosion : MonoBehaviour
    {
        [Header("音效")]
        public AudioClip sound;
        [Header("音量"), Range(0, 10)]
        public float volume = 1;
        [Header("爆炸特效")]
        public GameObject explosion;
        [Header("丟擲物件標籤")]
        public string tagThrowable = "炸彈";

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == tagThrowable)
            {
                GameObject temp = Instantiate(explosion, transform.position, transform.rotation);
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                Destroy(gameObject, 1);
                Destroy(temp, 2);
            }
        }
    }
}