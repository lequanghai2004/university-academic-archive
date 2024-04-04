import cv2
import face_detect
img=cv2.imread("download.png")

zone=face_detect.detect(img)

for(x,y,w,h) in zone:
    cv2.rectangle(img,(x,y),(x+w,y+h),(0,255,0),2)
cv2.imshow("image",img)
cv2.waitKey(0)