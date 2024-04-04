import numpy as np

#copy -> new arr
#view -> original arr
arr1 = np.array([1, 2, 3, 4, 5])
arr2 = arr1.copy()
arr3 = arr1.view()
arr1[0] = 0
print(arr1, arr2) 
print(arr1, arr3)
#base returns None if the array owns the data. Otherwise, it refers to the original object
print(arr1.base, arr2.base, arr3.base)

def function(arg1, arg2):
  return arg1 + arg2

print(function(arr1, arr2))

class Human:
  def __init__(self, name,):
    self.name = name
  def eat():
    return "eat"

human = Human("Hai")
human.eat()
