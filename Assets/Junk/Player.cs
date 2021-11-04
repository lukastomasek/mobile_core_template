using UnityEngine;


namespace Mobile_Test
{
    public class Player : MonoBehaviour
    {
      
        [SerializeField] float playerSpeed = 1f;
        [SerializeField] float booster = 2f;
    
        Vector3 cameraPos;
        Rigidbody _rb;
        Camera _cam;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _cam = Camera.main;
        }


        private void FixedUpdate()
        {
          
            // get camera view port edge position 
            cameraPos = _cam.WorldToViewportPoint(transform.position);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (cameraPos.x <= 0.15f )
                    return;

                _rb.MovePosition(transform.position + new Vector3(-playerSpeed, 0, 0).normalized * Time.fixedDeltaTime * booster);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (0.85f <= cameraPos.x)
                    return;

                _rb.MovePosition(transform.position + new Vector3(playerSpeed, 0, 0).normalized * Time.fixedDeltaTime * booster);

            }
        }

    }

}
