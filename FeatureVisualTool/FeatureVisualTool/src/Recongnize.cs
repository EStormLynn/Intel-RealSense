using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFolderBrowserDialog
{
    class Recongnize
    {
        public Recongnize()
        {
            //_result = EmotionLabel.Normal;
        }


        public void DeltaEulidean(FeatureEuclidean f1,FeatureEuclidean f2)
        {
            _result = EmotionLabel.Normal.ToString();

            Dictionary<EmotionLabel, bool> emotion=new Dictionary<EmotionLabel,bool>();

            emotion.Add(EmotionLabel.Anger, false);
            emotion.Add(EmotionLabel.Happiness, false);
            emotion.Add(EmotionLabel.Sadness, false);
            emotion.Add(EmotionLabel.Surprise, false);
            emotion.Add(EmotionLabel.Disgust, false);
            emotion.Add(EmotionLabel.Fear, false);



            //Suprise
            if (Math.Abs(f1.Feature[20] - f2.Feature[20]) > 18)     //Suprise
            {
                emotion[EmotionLabel.Surprise] = true;
                _result = EmotionLabel.Surprise.ToString();
            }

            //Happyness
            int[] a = { 15, 16, 22, 23 };                            //Happyness
            int tag = 0;
            for (int i = 0; i < 4; i++)
            {
                if ((Math.Abs(f1.Feature[a[i]] - f2.Feature[a[i]]) > 10))
                {
                    tag++;                
                }
            }
            if (_result!="Surprise"&&tag >= 4)
            {
                _result = EmotionLabel.Happiness.ToString();
                emotion[EmotionLabel.Happiness] = true;
            }

            //sadness
            if ((Math.Abs(f1.Feature[3] - f2.Feature[3]) > 2))            //sadness
                if ((Math.Abs(f1.Feature[22] - f2.Feature[22]) > 8))
                    if ((Math.Abs(f1.Feature[23] - f2.Feature[23]) > 8))
                    {
                        _result = EmotionLabel.Sadness.ToString();
                        emotion[EmotionLabel.Sadness] = true;

                    }


            //angry
            if ((Math.Abs(f1.Feature[19] - f2.Feature[19]) > 8))                 //angry
              //  if ((Math.Abs(f1.Feature[21] - f2.Feature[21]) > 5))
                    if ((Math.Abs(f1.Feature[15] - f2.Feature[15]) > 10))
                        if ((Math.Abs(f1.Feature[16] - f2.Feature[16]) > 10))
                            if ((Math.Abs(f1.Feature[3] - f2.Feature[3]) > 4))
                            {
                            _result = EmotionLabel.Anger.ToString();
                            emotion[EmotionLabel.Anger] = true;
                        }

            float tag_11_12 = f1.Feature[11] - f2.Feature[11] + f1.Feature[12] - f2.Feature[12];
            //fear
            if ((Math.Abs(f1.Feature[2] - f2.Feature[2]) > 4))            //fear
                if ((Math.Abs(f1.Feature[22] - f2.Feature[22]) > 8))
                    if ((Math.Abs(f1.Feature[23] - f2.Feature[23]) > 8))
                        if ((Math.Abs(f1.Feature[20] - f2.Feature[20]) > 10))
                            if (tag_11_12 < -4)
                            {
                                _result = EmotionLabel.Fear.ToString();
                                emotion[EmotionLabel.Fear] = true;
                            }

            //disgust
            if ((Math.Abs(f1.Feature[14] - f2.Feature[14]) > 8))            //disgust
                if ((Math.Abs(f1.Feature[13] - f2.Feature[13]) > 8))
                    if ((Math.Abs(f1.Feature[20] - f2.Feature[20]) > 10))
                        if (tag_11_12 > 2) 
                        {
                            _result = EmotionLabel.Disgust.ToString();
                            emotion[EmotionLabel.Disgust] = true;
                        }

            emotion.Clear();
        }
        #region 字段

        private string _result;
        Dictionary<EmotionLabel, bool> emotion = new Dictionary<EmotionLabel, bool>();

        public string GetResult
        {
            get { return _result; }
            set { _result = value; }
        }

        #endregion
        enum EmotionLabel
        {
            Normal = 0,
            Anger = 1,
            Happiness = 2,
            Sadness = 3,
            Surprise = 4,
            Disgust = 5,
            Fear = 6,
        }


    }
}
