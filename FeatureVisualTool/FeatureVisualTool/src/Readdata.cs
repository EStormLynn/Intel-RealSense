using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestFolderBrowserDialog
{
    class Readdata
    {

        //private List<PointRecorder> _facedata = new List<PointRecorder>();
        #region 构造方法
        public Readdata(string path)
        {
            if (path == null)
                return;
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                _framesum++;
                string[] strArray= line.Split('\t');
                SavaData(strArray);

            }
            ReaddataAllFrame(path, _framesum);




            FeatureEuclidean firstfacedata = new FeatureEuclidean(_firstfacedata);
            FeatureEuclidean nowfacedata = new FeatureEuclidean(_nowfacedata);
            CatureFeature(firstfacedata,1);
            CatureFeature(nowfacedata,_framesum);
            
        }
        #endregion


        public void ReaddataByFrame(string path,int n)
        {
            if (path == null)
                return;
            int i = 1;
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            while (((line = sr.ReadLine()) != null))
            {
                if (i == n)
                    break;
                i++;
            }
            string[] strArray = line.Split('\t');
            SavaData(strArray);

            FeatureEuclidean firstfacedata = new FeatureEuclidean(_firstfacedata);
            FeatureEuclidean nowfacedata = new FeatureEuclidean(_nowfacedata);
            CatureFeature(nowfacedata, n);
            CatureFeature(firstfacedata,nowfacedata);

            Recongnize rec = new Recongnize();//识别类           
            rec.DeltaEulidean(firstfacedata, nowfacedata);
           
            _result=rec.GetResult;    
            
        }

        private void ReaddataAllFrame(string path,int n)
        {
            _resultList.Clear();

            if (path == null)
                return;
            int i = 1,tag=0;
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            while (((line = sr.ReadLine()) != null))
            {
                if (i == n)
                    break;

                string[] strArray = line.Split('\t');
                SavaData(strArray);

                FeatureEuclidean firstfacedata = new FeatureEuclidean(_firstfacedata);
                FeatureEuclidean nowfacedata = new FeatureEuclidean(_nowfacedata);
                CatureFeature(nowfacedata, n);
                CatureFeature(firstfacedata, nowfacedata);

                Recongnize rec = new Recongnize();//识别类           
                rec.DeltaEulidean(firstfacedata, nowfacedata);

                if (rec.GetResult != "Normal")
                //    tag = 1;
                //if(tag==1)
                _resultList.Add(rec.GetResult);

                i++;
            }



            _result=ReturnAnsRate(_resultList);

            int di = 0;

        }

        //统计result数组中，最多表情，且满足识别率高于80%
        private string ReturnAnsRate(List<string> resultList)
        {
            if (resultList.Count == 0)
                return "未识别出任何表情";


            Dictionary<string,int> dic= new Dictionary<string, int>();

            string ans=null;
            int times=0;
            float rate;
            for(int i=0;i<resultList.Count;i++)
            {
                if (times == 0)
                {
                    ans = resultList[i];
                    times = 1;
                }
                else if (ans == resultList[i])
                    times++;
                else
                    times--;
            }

            times = 0;
            for (int i = 0; i < resultList.Count; i++)
            {
                if (ans == resultList[i])
                {
                    times++;
                }
            }


            rate = (float)(times) * 100 / (float)resultList.Count;



            return ans +rate.ToString()+"%";
                
        }

        public string ReturnResult()
        {
            
            return _result;
        }

        public  void SavaData(string[] strArray)
        {
            for(int i=3;i<strArray.Length-7;i+=7)//数据中第四个元素为第一个点的标号
            {
                Point position = new Point();
                position.World_x = float.Parse(strArray[i + 2]);
                position.World_y = float.Parse(strArray[i + 3]);
                position.World_z = float.Parse(strArray[i + 4]);

                position.Image_x = float.Parse(strArray[i + 5]);
                position.Image_y = float.Parse(strArray[i + 6]);

                int LandmarkID = int.Parse(strArray[i]);
                //
                PointRecorder ptr = new PointRecorder(LandmarkID, position);

                if (!_facedata.ContainsKey(LandmarkID))
                {
                    _facedata[LandmarkID] = ptr;
                    _firstfacedata[LandmarkID] = ptr;

                }
                _nowfacedata[LandmarkID] = ptr;
                _facedata[LandmarkID].Update(position);
            }
            
        }

        private void CatureFeature(FeatureEuclidean firstFeature,FeatureEuclidean nowFeature)//差值
        {
            
            float[] f1 = firstFeature.Feature;
            float[] f2 = nowFeature.Feature;


            for(int i=1;i<26;i++)
            {
                _delta[2,i] = f2[i] - f1[i];
            }
        }


        private void CatureFeature(FeatureEuclidean frameFeature,int n)//计算距离特征方法重载,第n帧
        {
            float[] f1 = frameFeature.Feature;
            if(n==1&&_delta[0,1]==0)
            {
                for (int i = 1; i < 26; i++)
                {
                    _delta[0, i] = f1[i];
                }
            }
            else if (n == _framesum && _delta[3, 1] == 0)
                {
                    for (int i = 1; i < 26; i++)
                    {
                        _delta[3, i] = f1[i];
                    }
                }
            else
            {
                for (int i = 1; i < 26; i++)
                {
                    _delta[1, i] = f1[i];
                }
            }
        }

        #region 字段
        private Dictionary<int, PointRecorder> _facedata = new Dictionary<int, PointRecorder>();
        private Dictionary<int, PointRecorder> _firstfacedata = new Dictionary<int, PointRecorder>();
        private Dictionary<int, PointRecorder> _nowfacedata = new Dictionary<int, PointRecorder>();
        private string _result;
        private List<string> _resultList = new List<string>();
        private float[,] _delta = new float[4,26]; 
        private int _framesum = 0;
        private static int _framenow = 1;


        #endregion

        #region 属性
        public float[,] Delta
        {
            get { return _delta; }
            set { _delta = value; }
        }

        public int Framenow
        {
            get { return _framenow; }
            set { _framenow = value; }
        }

        public int Framesum
        {
            get { return _framesum; }
            set { _framesum = value; }
        }
        #endregion

    }
}
