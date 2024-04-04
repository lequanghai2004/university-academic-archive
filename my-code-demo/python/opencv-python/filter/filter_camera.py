import argparse
import cv2
from filter import *

cam = cv2.VideoCapture(0)

while True:
    _, img = cam.read()
    
    cv2.imshow("Camera", cartoonize(img))

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

cam.release()
cv2.destroyAllWindows()