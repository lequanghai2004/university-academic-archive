import numpy as np

a = np.array([[1, 2, 3, 4, 5], [6, 7, 8, 9, 10], [11, 12, 13, 14, 15]])
print("a.shape:", a.shape)
print("a.ndim:", a.ndim)
print("a.dtype:", a.dtype)
print("a.itemsize:", a.itemsize)
print("a.data:", a.data)

# Slicing
print('Slicing 2D:', a[2, 3:5])

b = np.array([[1, 2], [3, 4]], dtype=complex)
print(b)

# default dtype: float 64
# create array full of 0 or 1 or random
c = np.zeros((3, 4))
d = np.ones((3, 4))
e = np.empty((3, 4))
print(c)
print(d)
print(e)
print(c.dtype, d.dtype)

print(np.arange(10, 30, 5))  # 10,15,20,25
print(np.arange(0, 2, 0.3))  # 0,0.3,0.6,..,1.8

print(np.linspace(0, 2, 9))  # 9 numbers from 0 to 2
x = np.linspace(0, 2 * np.pi, 10)  # useful to evaluate function at lots of points
f = np.sin(x)
print(x)
print(f)

# create array
arr1 = np.arange(10);
print(arr1)
arr2 = np.arange(12).reshape(4, 3);
print(arr2)
arr3 = np.arange(24).reshape(2, 3, 4);
print(arr3)

arr10 = np.array([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12])
newarr = arr10.reshape(4, 3);
print(newarr)
