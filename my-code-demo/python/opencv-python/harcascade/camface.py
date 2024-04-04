import cv2
import simpleface

cam = cv2.VideoCapture(0)

while True:
    _, img = cam.read()

    for (x, y, w, h) in simpleface.detect(img):
        cv2.rectangle(img, (x, y), (x+w, y+h), (0, 255, 0), 2)

    cv2.imshow("Camera", img)

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

cam.release()
cv2.destroyAllWindows()

    for (x, y, w, h) in zones:
        cv2.rectangle(img, (x, y), (x+w, y+h), (0, 255, 0), 2)

    cv2.imshow("image", img)
    cv2.waitKey(0)
