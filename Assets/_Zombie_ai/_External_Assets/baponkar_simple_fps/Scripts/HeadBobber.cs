using UnityEngine;

namespace Baponkar.FPS.Simple
{
    public class HeadBobber : MonoBehaviour
    {
        public float walkingBobbingSpeed = 14f;
        public float bobbingAmount = 0.05f;
        public PlayerMovement playerMovement;

        float defaultPosY = 0;
        float timer = 0;

        // Start is called before the first frame update
        void Start()
        {
            defaultPosY = transform.localPosition.y;
        }

        // Update is called once per frame
        void Update()
        {
            if(Mathf.Abs(playerMovement.movement.x) > 0.1f || Mathf.Abs(playerMovement.movement.z) > 0.1f)
            {
                //Player is moving
                timer += Time.deltaTime * walkingBobbingSpeed;
                transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
            }
            else
            {
                //Idle
                timer = 0;
                transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
            }
        }
    }
}