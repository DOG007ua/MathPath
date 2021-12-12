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

        public void Move(Vector2 position)
        {
            transform.position = position + new Vector2(0, controllerPlayer.Size / 2.0f);
        }
    }
}