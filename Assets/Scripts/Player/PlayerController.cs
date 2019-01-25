using UnityEngine;

namespace Dima.Player {
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour {

        [Header("Ground Movement")]
        public float moveSpeed = 9f;
        public float groundAcceleration = 200f;
        public float deacceleration = 5f;

        [Header("Jumping")]
        public float jumpForce = 5f;

        [Header("Air Movement")]
        public float gravity = 31f;
        public float airAcceleration = 50;
        
        // Data
        [HideInInspector]
        public Vector3 velocity;

        // Misc
        private CharacterController controller;

        void Awake() {
            controller = GetComponent<CharacterController>();
        }

        void Update() {
            CheckInput();
            Accelerate();
            ApplyGravity();
            ApplyVelocity();
            Deaccelerate();
        }

        void Accelerate() {
            // Take input and add it to our velocity
            float acc = controller.isGrounded == true ? groundAcceleration : airAcceleration;
            Vector3 wishDir = transform.TransformDirection(PlayerInput.GetMovementInput).normalized * acc * Time.deltaTime;
            velocity += wishDir;

            // Clamp velocity
            Vector2 clampVel = new Vector3(velocity.x, velocity.z);
            clampVel = Vector2.ClampMagnitude(clampVel, moveSpeed);
            velocity = new Vector3(clampVel.x, velocity.y, clampVel.y);
        }

        void Deaccelerate() {
            if (controller.isGrounded) {
                velocity.x = Mathf.Lerp(velocity.x, 0, deacceleration * Time.deltaTime);
                velocity.z = Mathf.Lerp(velocity.z, 0, deacceleration * Time.deltaTime);
            }
        }

        void ApplyGravity() {
            // Airborne
            if (!controller.isGrounded)
                velocity.y -= gravity * Time.deltaTime;
            // Grounded
            //else if (velocity.y < 0)
            //velocity.y = 0;
        }

        void ApplyVelocity() {
            controller.Move(velocity * Time.deltaTime);
        }

        void CheckInput() {
            // Jumping
            if (Input.GetKeyDown(KeyCode.Space)) {
                Jump();
            }
        }

        void Jump() {
            if (controller.isGrounded) {
                velocity.y = jumpForce;
            }
        }
    }
}