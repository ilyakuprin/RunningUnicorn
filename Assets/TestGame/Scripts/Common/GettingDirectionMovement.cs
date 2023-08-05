using UnityEngine;

namespace RunningUnicorn
{
    public enum Direction
    {
        left,
        right
    };

    public class GettingDirectionMovement
    {
        public Vector3 GetDirection(Direction dayTime)
        {
            switch (dayTime)
            {
                case Direction.left:
                    return Vector3.left;
                case Direction.right:
                    return Vector3.right;
                default:
                    return Vector3.zero;
            }
        }
    }
}
