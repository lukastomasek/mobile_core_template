using UnityEngine;

namespace Mobile_Test
{
    public class AnimCurve : MonoBehaviour
    {
        [SerializeField] AnimationCurve motionCurve;
        [SerializeField, Range(1f, 10f)] float motionSpeed = 5f;

        float _motionTimer = 0;

        private void Start()
        {
            //    motionCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
            motionCurve.preWrapMode = WrapMode.PingPong;
            motionCurve.postWrapMode = WrapMode.PingPong;

        }

        private void Update()
        {
           transform.position = new Vector3(transform.position.x, motionCurve.Evaluate(Time.time), transform.position.z);

           
        }
    }



}