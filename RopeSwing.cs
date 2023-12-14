using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSwing : MonoBehaviour
{
    [Header("References")]
    public LineRenderer lr;
    public Transform _gunTip, _cam, _player;
    public LayerMask _whatIsGrappleable;
    public FPSController _FPSContoller;

    [Header("Swinging")]
    private float _maxSwingDistance = 25f;
    private Vector3 _swingPoint;
    private SpringJoint _joint;

    [Header("OdmGear")]
    public Transform _orientation;
    public Rigidbody _rb;
    public float _horizontalThrustForce;
    public float _forwardThrustForce;
    public float _extendCableSpeed;

    [Header("Prediction")]
    public RaycastHit _predictionHit;
    public float _predictionSphereCastRadius;
    public Transform _predictionPoint;

    [Header("Input")]
    public KeyCode _swingKey = KeyCode.Mouse0;

    private void Update()
    {
        if (Input.GetKeyDown(_swingKey)) StartSwing();
        if (Input.GetKeyUp(_swingKey)) StopSwing();

        CheckForSwingPoints();

        if (_joint != null) OdmGearMovement();
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void CheckForSwingPoints()
    {
        if (_joint != null) return;

        RaycastHit sphereCastHit;
        Physics.SphereCast(_cam.position, _predictionSphereCastRadius, _cam.forward, out sphereCastHit, _maxSwingDistance, _whatIsGrappleable);

        RaycastHit raycastHit;
        Physics.Raycast(_cam.position, _cam.forward, out raycastHit, _maxSwingDistance, _whatIsGrappleable);

        Vector3 realHitPoint;

        // Option 1 - Direct Hit
        if (raycastHit.point != Vector3.zero)
            realHitPoint = raycastHit.point;
        // Option 2 - Indirect (predicted) Hit
        else if (sphereCastHit.point != Vector3.zero)
            realHitPoint = sphereCastHit.point;
        // Option 3 - Miss
        else
            realHitPoint = Vector3.zero;

        // realHitPoint found
        if (realHitPoint != Vector3.zero)
        {
            _predictionPoint.gameObject.SetActive(true);
            _predictionPoint.position = realHitPoint;
        }
        // realHitPoint not found
        else
        {
            _predictionPoint.gameObject.SetActive(false);
        }

        _predictionHit = raycastHit.point == Vector3.zero ? sphereCastHit : raycastHit;
    }

    private void StartSwing()
    {
        // return if _predictionHit not found
        if (_predictionHit.point == Vector3.zero) return;

        // deactivate active grapple
        //if (GetComponent<Grappling>() != null)
        //    GetComponent<Grappling>().StopGrapple();
        //_FPSContoller.ResetRestrictions();

        _FPSContoller._swinging = true;

        _swingPoint = _predictionHit.point;
        _joint = _player.gameObject.AddComponent<SpringJoint>();
        _joint.autoConfigureConnectedAnchor = false;
        _joint.connectedAnchor = _swingPoint;

        float distanceFromPoint = Vector3.Distance(_player.position, _swingPoint);

        // the distance grapple will try to keep from grapple point.
        _joint.maxDistance = distanceFromPoint * 0.8f;
        _joint.minDistance = distanceFromPoint * 0.25f;

        // customize values as needed
        _joint.spring = 4.5f;
        _joint.damper = 7f;
        _joint.massScale = 4.5f;

        lr.positionCount = 2;
        _currentGrapplePosition = _gunTip.position;
    }

    public void StopSwing()
    {
        _FPSContoller._swinging = false;
        lr.positionCount = 0;
        Destroy(_joint);
    }

    private void OdmGearMovement()
    {
        // right
        if (Input.GetKey(KeyCode.D)) _rb.AddForce(_orientation.right * _horizontalThrustForce * Time.deltaTime);
        // left
        if (Input.GetKey(KeyCode.A)) _rb.AddForce(-_orientation.right * _horizontalThrustForce * Time.deltaTime);
        // forward
        if (Input.GetKey(KeyCode.W)) _rb.AddForce(_orientation.forward * _horizontalThrustForce * Time.deltaTime);
        // shorten cable
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 directionToPoint = _swingPoint - transform.position;
            _rb.AddForce(directionToPoint.normalized * _forwardThrustForce * Time.deltaTime);

            float distanceFromPoint = Vector3.Distance(transform.position, _swingPoint);

            _joint.maxDistance = distanceFromPoint * 0.8f;
            _joint.minDistance = distanceFromPoint * 0.25f;
        }
        // extend cable
        if (Input.GetKey(KeyCode.S))
        {
            float extendedDistanceFromPoint = Vector3.Distance(transform.position, _swingPoint) + _extendCableSpeed;

            _joint.maxDistance = extendedDistanceFromPoint * 0.8f;
            _joint.minDistance = extendedDistanceFromPoint * 0.25f;
        }
    }

    private Vector3 _currentGrapplePosition;

    private void DrawRope()
    {
        // if not grappling, don't draw rope
        if (!_joint) return;

        _currentGrapplePosition = Vector3.Lerp(_currentGrapplePosition, _swingPoint, Time.deltaTime * 8f);

        lr.SetPosition(0, _gunTip.position);
        lr.SetPosition(1, _currentGrapplePosition);
    }
}
