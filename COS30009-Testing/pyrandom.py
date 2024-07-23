import random
import numpy

# set reproducable random algorithm
random.seed(10)
print(numpy.random.seed(0))


# inputs and weights (optional)
names = ['John','Peter','Mary']
weights = [0.5, 0.2, 0.3]

# uniform distribution
print('Uniform distribution of names:')
for _ in range(10):
    print(random.choice(names))

# non-uniform distribution
print('Non-uniform distribution of names:')
for _ in range(10):
    print(random.choices(names, weights=weights)[0])


# random algorithm in numpy
print(numpy.random.rand(10),'random values in a given shape')
print(numpy.random.randn(2),'sample from “standard normal” distribution')
print(numpy.random.randint(100),'random integers 10[, high, size, dtype]')
print(numpy.random.exponential(scale=1.0),'draw samples from an exponential distribution')
print(numpy.random.pareto(5),'draw samples from a pareto distribution')


# random algorithm in numpy
print(random.random(),'random value in the range of [0,1]')
print(random.uniform(5,15),'random value in the range of [a,b]')
print(random.expovariate(5),'draw samples from an exponential distribution with lamda')
print(random.choice(['a','b'],'uniform samples from a list'))
print(random.choices(['a','b'],weights=[0.1,0.9]),'non-uniform samples from a list following an distribution')
