using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFolderBrowserDialog
{
    class FeatureEuclidean
    {
        /// <summary>
        /// 特征点之间的25个欧氏距离
        /// </summary>
        /// <param name="_facedata"></param>
        private enum FeatureName{
            //1 右眼眉毛外边界点-右眼眉毛内边界点   (4,0)
            EYEBROW_RIGHT_RIGHT_to_RIGHT_LEFT,

            //2 左眼眉毛外边界点-左眼眉毛内边界点   (9,5)
            EYEBROW_LEFT_RIGHT_to_LEFT_LEFT,

            //3 右眼眉毛内边界点-左眼眉毛内边界点   (0,5)
            EYEBROW_RIGHT_RIGHT_to_LEFT_RIGHT,

            //4 右眼内眼角点-左眼内眼角点           (10,18)
            EYELID_RIGHT_LEFT_to_LEFT_RIGHT,

            //5 右眼眉毛内边界点-右眼内眼角点       (0,10)
            EYEBROW_RIGHT_LEFT_to_EYELID_RIGHT_LEFT,

            //6 左眼眉毛内边界点-左眼内眼角点       (5,18)
            EYEBROW_LEFT_RIGHT_to_EYELID_LEFT_RIGHT,

            //7 右眼眉毛外边界点-右眼外眼角点       (4,14)
            EYEBROW_RIGHT_RIGHT_to_EYELID_RIGHT_RIGHT,

            //8 左眼眉毛外边界点-左眼外眼角点       (9,22)
            EYEBROW_LEFT_LEFT_to_EYELID_LEFT_LEFT,

            //9 右眼内眼角点-右眼外眼角点           (10,14)
            EYELID_RIGHT_LEFT_to_RIGHT_RIGHT,

            //10 左眼内眼角点-左眼外眼角点          (18,22)
            EYELID_LEFT_RIGHT_to_LEFT_LEFT,

            //11 右上眼皮中点-右下眼皮中点          (12,16)
            EYELID_RIGHT_TOP_to_RIGHT_BOTTOM,

            //12 左上眼皮中点-左下眼皮中点          (20,24)
            EYELID_LEFT_TOP_to_LEFT_BOTTOM,

            //13 右眼内眼角点-右鼻翼点              (10,30)
            EYELID_RIGHT_LEFT_to_NOSE_RIGHT,

            //14 左眼内眼角点-左鼻翼点              (18,32)
            EYELID_LEFT_RIGHT_to_NOSE_LEFT,

            //15 右眼外眼角点-右嘴角点              (14,33)
            EYELID_RIGHT_RIGHT_to_LIP_RIGHT,

            //16 左眼外眼角点-左嘴角点              (22,39)
            EYELID_LEFT_LEFT_to_LIP_LEFT,

            //17 右鼻翼点-右嘴角点                  (30,33)
            NOSE_RIGHT_to_LIP_RIGHT,
            
            //18 左鼻翼点-左嘴角点                  (32,39)
            NOSE_LEFT_to_LIP_LEFT,
            
            //19 鼻尖点-上嘴唇中点                  (29,47)
            NOSE_TIP_to_UPPER_LIP_CENTER,

            //20 上嘴唇中点-下嘴唇中点              (47,51)
            UPPER_LIP_CENTER_to_LOWER_LIP_CENTER,

            //21 下嘴唇中点-下巴点                  (51,61)
            LOWER_LIP_CENTER_to_CHIN,

            //22 右嘴角点-下巴点                    (33,61)
            LIP_RIGHT_to_CHIN,

            //23 左嘴角点-下巴点                    (39,61)
            LIP_LEFT_to_CHIN,

            //24 鼻尖点-右眼内眼角点                (29,10)
            NOSE_TIP_to_EYELID_RIGHT_LEFT,

            //25 鼻尖点-左眼内眼角点                (29,18)
            NOSE_TIP_to_EYELID_LEFT_RIGHT,
        }

        public FeatureEuclidean(Dictionary<int, PointRecorder> _facedata)
        {
            int[,] a=new int[26,2]{{0,0},{4,0},{9,5},{0,5},{10,18},{0,10},
                                        {5,18},{4,14},{9,22},{10,14},{18,22},
                                        {12,16},{20,24},{10,30},{18,32},{14,33},
                                        {22,39},{30,33},{32,39},{29,47},{47,51},
                                        {51,61},{33,61},{39,61},{29,10},{29,18}};
            int t = 1;
            for (int i = 1; i < 26;i++ )
            {
                _feature[t++] = Getdistance(_facedata[a[i, 0]].FirstPosition, _facedata[a[i, 1]].FirstPosition);
            }
        }

        private float Getdistance(Point A,Point B)
        {
            float dis = 0;
            dis = (float)Math.Sqrt(((A.Image_x - B.Image_x) * (A.Image_x - B.Image_x) + (A.Image_y - B.Image_y) * (A.Image_y - B.Image_y)));
            return dis;
        }


        #region 字段
        float[] _feature = new float[26];
       
        public float[] Feature
        {
            get { return _feature; }
            set { _feature = value; }
        }

        #endregion

    }
}
