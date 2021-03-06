#coding=utf-8
from PIL import Image, ImageDraw, ImageFont
import os

def drawLandmarkPoint(img,color):
    draw = ImageDraw.Draw(img)
    myfont = ImageFont.truetype("C:\\WINDOWS\\Fonts\\SIMYOU.TTF", 10)

    file_txt = open("S035_003_00000001_landmarks.txt", "a+")
    lines = file_txt.readlines()
    t=1
    for line in lines:
        line_object=line.split(" ")
        x=float(line_object[3])
        y=float(line_object[-1])
        print x,y
        #draw.ellipse((0, 0, 200, 200), fill="red", outline="red")
        draw.text((x,y), bytes(t), font=myfont, fill=color)
        t+=1
    file_txt.close()

def ExtracMatrix(dir,matrixDir):
    global matrixcount
    matrixcount+=1

    matrix=[(['0']*490)for i in range(640)]

    file_txt=open(dir,"r")
    matrix_file=open(matrixDir,"w")

    lines=file_txt.readlines()
    for n in range(0,66):
    #for n in range(1, lines_count+1):
        line = lines[CK_to_RealSense[RealSenseID[n]]-1]
        line_object = line.split(' ')

        image_x = float(line_object[3])
        image_y = float(line_object[-1])
        i=int(image_x)
        j=int(image_y)

        if n==60:
            b=5
        matrix[i][j]='1'

    for i in range(0,490):
        for j in range(0,640):
            matrix_file.write(matrix[j][i])
        matrix_file.write("\n")

    matrix_file.close()
    print "__________"+str(matrixcount)


def readFile(filepath):
    f1 = open(filepath, "r")
    nowDir = os.path.split(filepath)[0]             #获取路径中的父文件夹路径
    fileName = os.path.split(filepath)[1]           #获取路径中文件名
    #对新生成的文件进行命名的过程

    lines = f1.readlines()
    str=lines[0]
    maxfileName=os.path.split(str)[1]
    l=len(maxfileName)
    maxfileName=maxfileName[0:l-1]

    MatrixDir = os.path.join(nowDir, "Matrix_"+maxfileName)
    maxframeDir=os.path.join(nowDir, maxfileName)

    ExtracMatrix(maxframeDir,MatrixDir)
    f_maxFrame=open(maxframeDir,"r")

    global picturecount
    picturecount+=1

def eachFile(filepath):
    global emotioncount

    pathDir = os.listdir(filepath)      #获取当前路径下的文件名，返回List
    for s in pathDir:
        newDir=os.path.join(filepath,s)     #将文件命加入到当前文件路径后面
        if os.path.isfile(newDir) :         #如果是文件
            if s=="maxframe.txt":  #判断是否是txt
                readFile(newDir)                     #读文件
                pass
        else:
            eachFile(newDir)                #如果不是文件，递归这个文件夹的路径
            emotioncount += 1


#将ck点转换成realsense的点 r:ck 共66个点。
CK_to_RealSense={0:22,1:21,2:20,3:19,4:18,
                 5:23,6:24,7:25,8:26,9:27,
                 10:10,11:39,12:38,14:37,16:42,17:41,
                 18:43,19:44,20:45,22:46,24:47,25:48,
                 26:28,27:29,28:30,29:31,30:32,31:34,32:36,
                 33:49,34:50,35:51,36:52,37:53,38:54,39:55,40:56,41:57,42:58,43:59,44:60,
                 45:61,46:62,47:63,48:64,49:65,50:66,51:67,52:68,
                 53:1,54:2,55:3,56:4,57:5,58:6,59:7,60:8,61:9,62:10,63:11,64:12,65:13,66:14,67:15,68:16,69:17
                 }
RealSenseID=[0,1,2,3,4,
             5,6,7,8,9,
             10,11,12,14,16,17,
             18,19,20,22,24,25,
             26,27,28,29,30,31,32,
             33,34,35,36,37,38,39,40,41,42,43,44,
             45,46,47,48,49,50,51,52,
             53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69
             ]


picturecount=0
emotioncount=0

matrixcount=0
eachFile(r"C:\Users\SeekHit\Documents\Tencent Files\1054777150\FileRecv\Landmarks(1)\Landmarks")
#print emotioncount-123,picturecount
print matrixcount
#readFile(r"E:\RealSense\CK+\Landmarks\S010\001\S010_001_00000001_landmarks.txt")
# print "共处理"+bytes(count)+"个txt"