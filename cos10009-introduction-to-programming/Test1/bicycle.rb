require_relative 'input_functions'

# Complete the code below
# Use input_functions to read the data from the user

class Bicycle
  def initialize(id, model, brand, colour)
    @id = id
    @model = model
    @brand = brand
    @colour = colour
  end

  attr_reader :id, :model, :brand, :colour
end

def read_bicycle -> Bicycle
  id = read_string('Enter bicycle id: ')
  model = read_string('Enter bicycle model: ')
  brand = read_string('Enter bicycle brand: ')
  colour = read_string('Enter bicycle colour: ')

  Bicycle.new(id, model, brand, colour)
end

def read_bicycles
  no_of_bicycles = read_integer('How many bicycles are you entering: ')
  bicycles = []
  no_of_bicycles.times do
    bicycle = read_bicycle
    bicycles << bicycle
  end
  bicycles
end

def print_bicycle(bicycle)
  puts("Bicycle id #{bicycle.id}
Model #{bicycle.model}
Brand #{bicycle.brand}
Colour #{bicycle.colour}")
end

def print_bicycles(bicycles)
  bicycles.each do |bicycle|
    print_bicycle(bicycle)
  end
end

def main
  bicycles = read_bicycles
  print_bicycles(bicycles)
end

main if __FILE__ == $0
