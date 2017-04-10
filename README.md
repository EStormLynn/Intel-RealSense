# Intel-RealSense
Intel-RealSense Emotion Recognize
使用RealSense SR300 DepthCamera作为采集设备，使用RealSense接口完成数据采集。
从CK+动态表情库中提取数据，转化成统一的RealSense标准。

## DF_FaceTracking.cs
从CK+动态表情库中提取，特征点信息  
 
版本：V1226    
修改：修改基础数据记录格式，FaceDate记录完整78个点，编号从0到77。     
      每行包含 日期 时间 Id (World_xyz Image_xy )*78 HeadPostion_xyz PoseEuler_pitch/roll/yaw  

版本：V1221     
修改：增加深度限定，面部离摄像头在25cm内，才能开始记录数据。      
      FaceDateLess记录原有32个点的数据

<div align=center><img src="https://github.com/EStormLynn/Intel-RealSense/blob/master/Image/界面.png" width="663" height="350" alt="程序界面"/></div>

## ExtrackMatrixFormCK+
特征点数据点云化，包含不同压缩率的矩阵压缩
```
tree /f
│  ExtractMatrixFromCK.py		    点云矩阵提取
│
└─MatrixCompression			        矩阵压缩
        MatrixCompression.py		压缩成66x490
        MatrixCompressionPlus.py	压缩成66x98
```
文件名*|说明|
---|---|---
Matrix_*|原始矩阵无压缩640x490|
MatrixCp_*|列未压缩，行为点间相对位置66x490|
matrixCpPlus_*|列压缩原来1/5，如果原尺寸5个像素点内的，偏移一个像素点，行为点间相对位置66x98 |



## FeatureVisualTool
FeatureVisualTool工具，可视化FaceTracking采集的数据，对特征进行观察，方便就行特征选取，验证数据有效性。    
 
主要完成：    
1.通过FolderBrowserDialog完成windows平台数据文件选取			    
2.计算每一帧图片的25维，欧氏距离特征    
3.可动态查看每一帧和中性表情特征变化差值     
4.采用投票的方式计算出可能为哪一种特征     

<div align=center><img src="https://github.com/EStormLynn/Intel-RealSense/blob/master/Image/FeatureVisualTool.png" width="663" height="350" alt="程序界面"/></div>

## Python Extrack Landmarks From CK+
从CK+动态表情库中提取，特征点信息  

主要完成：  
1.将CK+库中表情的特征点和Realsense采集的特征点关联，进行转换   
2.将每个表情的多张图片序列，数据信息整合到一个txt中，方便做动态表情识别   
3.实现Python递归动态处理一个目录下多个文件夹，多个文件的数据  

#### 将ck点转换成realsense的点 r:ck 共66个点。
```
CK_to_RealSense={0:22,1:21,2:20,3:19,4:18,
                 5:23,6:24,7:25,8:26,9:27,
                 10:10,11:39,12:38,14:37,16:42,17:41,
                 18:43,19:44,20:45,22:46,24:47,25:48,
                 26:28,27:29,28:30,29:31,30:32,31:34,32:36,
                 33:49,34:50,35:51,36:52,37:53,38:54,39:55,40:56,41:57,42:58,43:59,44:60,
                 45:61,46:62,47:63,48:64,49:65,50:66,51:67,52:68,
                 53:1,54:2,55:3,56:4,57:5,58:6,59:7,60:8,61:9,62:10,63:11,64:12,65:13,66:14,67:15,68:16,69:17
                 }
```
<div align=center><img src="https://github.com/EStormLynn/Intel-RealSense/blob/master/Image/landmarkPoint%20of%20RS%20and%20CK%2B.png" width="680" height="350" alt="landmarkPoint of RS and CK+"/></div>