# Print array and return count of elements calculated
# as we print them

def print_list_recursive(list)
  return if list.length == 0

  puts ' List Element is: ' + list[0].to_s
  print_list_recursive(list[1..list.size])
end

def main
  list = %w[a b c d e f]
  print_list_recursive(list)
  puts 'The list contained ' + list.size.to_s + ' elements.'
end

main
