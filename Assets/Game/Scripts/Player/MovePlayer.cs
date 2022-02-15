using UnityEngine;

namespace Player
{
    public class MovePlayer : IMovePlayer
    {
        private readonly GameObject gameObject;
        private ControllerPlayer controllerPlayer;  

        public MovePlayer(GameObject gameObject, ControllerPlayer controllerPlayer)
        {
            this.gameObject = gameObject;
            this.controllerPlayer = controllerPlayer;
        }
        
        public void Move(Vector3 position)
        {
            var positionY = controllerPlayer.Size / 2.0f + 0.3f;
            gameObject.transform.position = new Vector3(position.x, positionY, position.z);
        }
    }
}