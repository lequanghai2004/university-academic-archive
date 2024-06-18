# Recursive Factorial

# Complete the following
def factorial(n, result = 1)
  return result if n == 1

  factorial(n - 1, result * n)
end

def main
  # Add to the following code to prevent errors for ARGV[0] < 1 and ARGV.length < 1
  if ARGV.length < 1
    puts("Incorrect argument - need a single argument with a value of 0 or more.\n")
  elsif ARGV[0].to_i < 1
    puts("Incorrect argument - need a single argument with a value of 0 or more.\n")
  else
    puts factorial(ARGV[0].to_i)
  end
end

main
