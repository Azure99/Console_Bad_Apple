import cv2
import numpy as np
from PIL import Image

#高度48 宽度64
H = 48
W = 64

#总帧数
cnt = 0

print("Char video maker by Azure99\nPress Enter to continue")
input()

print("Reading video")
video = cv2.VideoCapture("video.flv")
while video.isOpened() :
    print("img%d" % cnt)
    r, img = video.read();
    try :
        gary = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    except :
        break
    cv2.imwrite("png\\%d.png" % cnt, img)
    cnt += 1

videoData = open("video.txt", "w")

#逐帧转换为字符图
for i in range(cnt):
    print("frame%d" % i)
    #读入图片并修改大小, 再转换为灰度图
    img = Image.open("png\\%d.png" % i, "r").resize((W, H)).convert("L")
    for Y in range(H):
        for X in range(W):
            pixel = img.getpixel((X, Y))
            #二值化
            if pixel < 200:
                videoData.write(" #")
            else :
                videoData.write("  ")
        videoData.write("\n")

videoData.close()
print("All done!Now you can move video.txt to C# Player folder")
