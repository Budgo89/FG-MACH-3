using System.Collections.Generic;
using System.Linq;
using MonoBehaviours;
using Tool;
using UnityEngine;

namespace Controllers
{
    internal class GamePlayController : BaseController
    {
        private Camera _camera;
        private List<GameObject> _balloons;
        private MenuDetected _menuDetected;
        private GameObject _highlightingFirstMove;
        private Transform _ballStorage;

        private bool _firstMoveFlag = true;

        public GamePlayController(Camera camera, List<GameObject> balloons, MenuDetected menuDetected, GameObject highlightingFirstMove, Transform ballStorage)
        {
            _camera = camera;
            _balloons = balloons;
            _menuDetected = menuDetected;
            _highlightingFirstMove = highlightingFirstMove;
            _ballStorage = ballStorage;
        }

        public void Update()
        {
            if(Input.GetMouseButtonDown(0))
                Raycast();
        }

        private void Raycast()
        {
            if (_menuDetected.IsVisible)
            {
                return;
            }
            
            var ray = _camera.ScreenPointToRay(Input.mousePosition).origin;
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            _balloons.Clear();

            if (hit.collider != null)
            {
                if (_firstMoveFlag)
                {
                    var a = hit.collider.gameObject.GetComponent<FirstMove>();
                    if (a == null)
                    {
                        return;
                    }
                    _firstMoveFlag = false;
                    _highlightingFirstMove.gameObject.SetActive(false);
                }
                var balloons = GetColor(hit);

                if(balloons != null)
                {
                    _balloons.Add(hit.collider.gameObject);
                    DoRaycast(hit, balloons);
                }
            }

            SetActiveBalloons();
        }

        private void SetActiveBalloons()
        {
            foreach (var balloon in _balloons)
            {
                    balloon.gameObject.transform.position = _ballStorage.position;
            }
        }

        private void DoRaycast(RaycastHit2D hit, IBalloons color)
        {
            List<RaycastHit2D> hit2Ds = Physics2D.CircleCastAll(hit.collider.gameObject.transform.position, 0.5f, Vector2.zero).ToList();
            foreach (var hit2D in hit2Ds)
            {
                var colorHit2D = GetColor(hit2D);
                if (colorHit2D == null)
                    continue;
                if (colorHit2D.Colors != color.Colors) 
                    continue;
                if (_balloons.Contains(hit2D.collider.gameObject)) 
                    continue;
                _balloons.Add(hit2D.collider.gameObject);
                DoRaycast(hit2D, color);
            }
        }
        private IBalloons GetColor(RaycastHit2D hit)
        {
            var blue = hit.collider.GetComponent<Blue>();
            var red = hit.collider.GetComponent<Red>();
            var green = hit.collider.GetComponent<Green>();
            var yellow = hit.collider.GetComponent<Yellow>();
            if (blue != null)
                return blue;
            if (red != null)
                return red;
            if (yellow != null)
                return yellow;
            if (green != null)
                return green;
            return null;
        }
    }
}
