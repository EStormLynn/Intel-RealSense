using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFolderBrowserDialog
{
    public class Point
    {
        #region 字段
        float _world_x;
        float _world_y;
        float _world_z;

        float _image_x;
        float _image_y;
        #endregion


        #region 属性

        public float World_x
        {
            get
            {
                return _world_x;
            }

            set
            {
                _world_x = value;
            }
        }

        public float World_y
        {
            get
            {
                return _world_y;
            }

            set
            {
                _world_y = value;
            }
        }

        public float World_z
        {
            get
            {
                return _world_z;
            }

            set
            {
                _world_z = value;
            }
        }

        public float Image_x
        {
            get
            {
                return _image_x;
            }

            set
            {
                _image_x = value;
            }
        }

        public float Image_y
        {
            get
            {
                return _image_y;
            }

            set
            {
                _image_y = value;
            }
        }
        #endregion
    }
}