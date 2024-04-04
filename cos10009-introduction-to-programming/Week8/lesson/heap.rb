
class Date 
	attr_accessor :day, :month, :year
end

def read_date()
	d = Date.new()
	puts "Enter day: "
	d.day = gets.chomp.to_i
	puts "Enter month: "
	d.month = gets.chomp.to_i
	puts "Enter year: "
	d.year = gets.chomp.to_i
	
	return d
end

def read_dates(max)
	dates = []
	
	index = 0
	while (index < max)
		dates << read_date()
		index += 1
	end
	return dates
end

def print_dates(dates)

	index = 0
	while (index < dates.length) do
		puts "Date is: #{dates[index].day}-#{dates[index].month}-#{dates[index].year}"
		index += 1
	end
end

def main
	
	dates = read_dates(2)
	print_dates(dates)
end

main

