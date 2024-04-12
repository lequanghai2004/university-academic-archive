import numpy as np

arr = np.array(42)
print(arr)

arr = np.array([[1, 2, 3, 4, 5], [6, 7, 8, 9, 10]])
print('Last element from 2nd dim: ', arr[1, -1])

a = np.array([1, 2, 3])
b = np.copy(a)
c = a
a[0] = 2004
print(a)
print(b)
print(c)

