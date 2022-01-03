using UnityEngine;

namespace Player
{
    public class MovePlayer : IMovePlayer
    {
        private readonly Transform transform;
        private ControllerPlayer controllerPlayer;  

        public MovePlayer(Transform transform, ControllerPlayer controllerPlayer)
        {
            this.transform = transform;
            this.controllerPlayer = controllerPlayer;
        }

        public void Move(Vector3 position)
        {
            var positionY = controllerPlayer.Size / 2.0f + 0.3f;
            transform.position = position + new Vector3(0, positionY, 0);
        }
    }
}