using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_4
{
    internal class Motorway
    {
        //properties and getter/setter
        private string _motorwayName;
        private char _motorwayDirection;
        private int _lanesCount;
        private bool _isToll;
        static string _maintainerName;

        public string MotorwayName
        {
            get { return _motorwayName; }
        }
        public char MotorwayDirection
        {
            get { return _motorwayDirection; }
            set { _motorwayDirection = value; }
        }
        public int LaneCount
        {
            get { return _lanesCount; }
            set { _lanesCount = value; }
        }
        public bool IsToll
        {
            get { return _isToll; }
            set { _isToll = value; }
        }
        public string MaintainerName
        {
            get { return _maintainerName; }
            set { _maintainerName = value; }
        }

        //methods
        public Motorway(string motorwayName)
        {
            _motorwayName = motorwayName;
            _lanesCount = 2;
            _isToll = false;
            _maintainerName = "The Family";
        }
        public Motorway(string motorwayName, char motorwayDirection, int lanesCount, bool isToll, string maintainerName)
        {
            _motorwayName = motorwayName;
            _motorwayDirection = motorwayDirection;
            _lanesCount = lanesCount;
            _isToll = isToll;
            _maintainerName = maintainerName;
        }
        public void GetDirectionName()
        {
            string fullDirection;
            switch(_motorwayDirection)
            {
                case 'E':
                    fullDirection = "East";
                    break;
                case 'W':
                    fullDirection = "West";
                    break;
                case 'N':
                    fullDirection = "North";
                    break;
                case 'S':
                    fullDirection = "South";
                    break;
                default:
                    fullDirection = "Unknown";
                    break;
            }
            Console.WriteLine(fullDirection + " " + _motorwayName);
        }
        public void IsTollRoad()
        {
            if(_isToll)
            {
                Console.WriteLine("Toll Road");
            }
            else
            {
                Console.WriteLine("Toll Free");
            }
        }
    }
}
