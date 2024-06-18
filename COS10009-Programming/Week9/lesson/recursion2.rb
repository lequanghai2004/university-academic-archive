# Print list recursively with count

def print_list_recursive_with_count(list)
  return 0 if list.length == 0

  puts ' List Element is: ' + list[0].to_s
  print_list_recursive_with_count(list[1..list.size]) + 1
end

def main
  list = %w[a b c d e f]
  count = print_list_recursive_with_count(list)
  puts 'The list contained ' + count.to_s + ' elements.'
end

main

