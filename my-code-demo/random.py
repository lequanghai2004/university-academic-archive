import random

min_value = -100
max_value = 100
min_length = 1 # List cannot be empty
max_length = 10 

def generate_random_list(min_value, max_value, min_length, max_length):
    length = random.randint(min_length, max_length)
    return [random.randint(min_value, max_value) for _ in range(length)]

generate_random_list(min_value, max_value, min_length, max_length)