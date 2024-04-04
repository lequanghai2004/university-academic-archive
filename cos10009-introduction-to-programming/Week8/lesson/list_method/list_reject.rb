list = [2, 4, 6, 8]
puts "Original list: "
puts list

newlist = list.reject do |i|
	if i > 2
		true
	else
		false
	end
end

puts("New list is: ")
puts newlist
		
