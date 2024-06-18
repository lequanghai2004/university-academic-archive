list =[2, 4, 6, 8]

newlist = list.collect do |i|
	i + 1
end

j = 0
newlist.each do |i|
	j += 1
	puts "Item #{j} is #{i}"
end