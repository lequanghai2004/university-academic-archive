# test_script.py
from program import calculate_statistics

def test_mrs():
    # Original data
    original_data = [1, 2, 3, 4, 5]
    print("Original Data:", original_data)
    
    # Calculate statistics for original data
    original_mean, original_variance = calculate_statistics(original_data)
    print(f"Original Mean: {original_mean}, Original Variance: {original_variance}")
    
    # MR1: Constant addition relation
    added_constant = 10
    new_data_mr1 = [x + added_constant for x in original_data]
    mean_mr1, variance_mr1 = calculate_statistics(new_data_mr1)
    print(f"MR1: New Data after addition: {new_data_mr1}")
    print(f"MR1: New Mean: {mean_mr1}, Variance: {variance_mr1}")
    print(f"MR1 Check: New Mean = Original Mean + {added_constant} -> {mean_mr1 == original_mean + added_constant}")
    print(f"MR1 Check: Variance remains the same -> {variance_mr1 == original_variance}")
    
    # MR2: Constant multiplication relation
    multiplier = 2
    new_data_mr2 = [x * multiplier for x in original_data]
    mean_mr2, variance_mr2 = calculate_statistics(new_data_mr2)
    print(f"MR2: New Data after multiplication: {new_data_mr2}")
    print(f"MR2: New Mean: {mean_mr2}, Variance: {variance_mr2}")
    print(f"MR2 Check: New Mean = Original Mean * {multiplier} -> {mean_mr2 == original_mean * multiplier}")
    print(f"MR2 Check: New Variance = Original Variance * {multiplier**2} -> {variance_mr2 == original_variance * multiplier**2}")
    
    # MR3: Data reversal relation
    new_data_mr3 = list(reversed(original_data))
    mean_mr3, variance_mr3 = calculate_statistics(new_data_mr3)
    print(f"MR3: Reversed Data: {new_data_mr3}")
    print(f"MR3: Mean: {mean_mr3}, Variance: {variance_mr3}")
    print(f"MR3 Check: Mean remains unchanged -> {mean_mr3 == original_mean}")
    print(f"MR3 Check: Variance remains unchanged -> {variance_mr3 == original_variance}")
    
    # MR4: Data subset relation
    subset_data = [2, 3, 4]
    mean_mr4, variance_mr4 = calculate_statistics(subset_data)
    print(f"MR4: Subset Data: {subset_data}")
    print(f"MR4: Mean: {mean_mr4}, Variance: {variance_mr4}")
    print(f"MR4 Check: Mean and Variance should be checked manually for correctness")

# Run the test cases
test_mrs()
