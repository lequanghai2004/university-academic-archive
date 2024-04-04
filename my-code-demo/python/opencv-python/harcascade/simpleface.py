import cv2

classifier = cv2.CascadeClassifier("code.xml")

def detect(img):
    global classifier

    grayscale = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    h, w = grayscale.shape
    size = min(h, w)
    nscale = size / 200

    if nscale > 1:
        grayscale = cv2.resize(grayscale, (int(w / nscale), int(h / nscale)))

    zones = classifier.detectMultiScale(
        grayscale,
        scaleFactor=1.2,
        minNeighbors=5,
        minSize=(30, 30),
        flags=cv2.CASCADE_SCALE_IMAGE
    )

    if nscale <= 1:
        return zones

    return [(int(x*nscale), int(y*nscale), int(rw*nscale), int(rh*nscale)) for (x, y, rw, rh) in zones]
