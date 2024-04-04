import argparse
import cv2

def cartoonize(img):
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    # blurImage = cv2.medianBlur(img, 1)
    edges = cv2.adaptiveThreshold(gray, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY, 9, 9)
    color = cv2.bilateralFilter(img, 9, 200, 200)
    cartoon = cv2.bitwise_and(color, color, mask = edges)

    cv2.imshow("color",color)
    cv2.imshow("edges",edges)
    return cartoon
   