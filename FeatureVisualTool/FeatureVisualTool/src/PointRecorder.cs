using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TestFolderBrowserDialog
{
    /// <summary>
    /// 点信息记录器
    /// </summary>
    /// 
    public class PointRecorder //: 
    {
        #region 构造及初始化
        
        public PointRecorder(int id, Point position)
        {
            _LandmarkId = id;
            _firstPosition = position;
            _createdAt = DateTime.Now;

            _updateTimes = 1;
            _lastPosition = position;



        }

        #endregion

        #region 事件

        #endregion

        #region 字段
        List<Point> pList = new List<Point>();

        private readonly int _LandmarkId;
        private readonly Point _firstPosition;
        private readonly DateTime _createdAt;

        private int _updateTimes;
        private Point _lastPosition;
        private double _lineslope;
        private double _distance;

        double _minX, _maxX, _minY, _maxY;

        #endregion

        #region 属性
        //public double LineSlope
        //{
        //    set
        //    {

        //    }
        //    get
        //    {
        //        if (_firstPosition != _lastPosition)
        //        {
        //            _lineslope = (_lastPosition.Y - _firstPosition.Y) / (_lastPosition.X - _firstPosition.X);
        //        }
        //        return _lineslope;
        //    }
        //}


        public Point FirstPosition
        {
            get { return _firstPosition; }
        }

        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }

        public int UpdateTimes
        {
            get
            {
                return _updateTimes;
            }
            private set
            {
                _updateTimes = value;
            }
        }

        public Point LastPosition
        {
            get
            {
                return _lastPosition;
            }
            private set
            {
                _lastPosition = value;
            }
        }

        public int LandmarkId
        {
            get
            {
                return _LandmarkId;
            }
        }



        #endregion

        #region 方法

        public void Update(Point position)
        {
            UpdateTimes++;
            LastPosition = position;
            pList.Add(position);
        }



        #endregion
    }
}
