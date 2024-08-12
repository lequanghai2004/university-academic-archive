# program.py
def calculate_statistics(numbers):
    if not numbers:
        return None, None
    
    mean = sum(numbers) / len(numbers)
    variance = sum((x - mean) ** 2 for x in numbers) / len(numbers)
    return mean, variance
