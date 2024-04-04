import cv2

classifier=cv2.CascadeClassifier('code.xml')


img=cv2.imread('abba.png')
grayscale=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)

zone = classifier.detectMultiScale(
    grayscale,
    scaleFactor=1.2,
    minNeighbors=5,
    minSize=(30, 30),
    flags=cv2.CASCADE_SCALE_IMAGE
)

for x,y,w,h in zone:
    cv2.rectangle(img,(x,y),(x+w,y+h),(0,255,0),2)


cv2.imshow('image',img)
cv2.waitKey(0)

































# https://codelearn.io/sharing/xu-ly-anh-voi-opencv-phan-1