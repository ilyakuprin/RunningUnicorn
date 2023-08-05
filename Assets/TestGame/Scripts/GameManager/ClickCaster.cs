using UnityEngine;

namespace RunningUnicorn
{
    public class ClickCaster
    {
        private readonly Camera _camera;

        public ClickCaster(Camera cam)
        {
            _camera = cam;
        }

        public GameObject GetGameObject(Vector3 _mousePosition)
        {
            GameObject hitObj = null;

            Ray ray = _camera.ScreenPointToRay(_mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero);

            if (hit.collider != null)
            {
                hitObj = hit.collider.gameObject;
            }

            return hitObj;
        }
    }
}
