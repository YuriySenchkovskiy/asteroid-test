using TMPro;
using UnityEngine;

namespace UI
{
    public class InformationPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coordinates;
        [SerializeField] private TextMeshProUGUI _angle;
        [SerializeField] private TextMeshProUGUI _speed;
        [SerializeField] private TextMeshProUGUI _laserCharges;
        [SerializeField] private TextMeshProUGUI _rechargeTimer;

        private const string Coordinates = "Coordinates: ";
        private const string Angle = "Angle of rotation: ";
        private const string Speed = "Speed: ";
        private const string LaserCharges = "Laser charges: ";
        private const string RechargeTimer = "Timer: ";

        public void SetCoordinates(Vector3 coordinates)
        {
            _coordinates.text = Coordinates + coordinates;
        }
        
        public void SetAngle(float angle)
        {
            _angle.text = Angle + angle;
        }
        
        public void SetSpeed(float speed)
        {
            _speed.text = Speed + speed;
        }
        
        public void SetLaserCharges(int number)
        {
            _laserCharges.text = LaserCharges + number;
        }
        
        public void SetTimer(float time)
        {
            _rechargeTimer.text = RechargeTimer + time;
        }
    }
}