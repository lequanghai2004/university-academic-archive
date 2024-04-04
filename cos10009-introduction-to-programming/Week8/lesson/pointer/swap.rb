class My_string
    attr_accessor :text
    def initialize(text)
        @text = text
    end
end

def swap(a, b)
  temp = My_string.new("nothing")

  # an object from a class acts as a pointer
  # obj.text indicates an address
  # however it can act as value (see in reference.rb)
  temp.text = a.text
  a.text = b.text
  b.text = temp.text

  puts "In swap a is: " + a.text
  puts "In swap b is: " + b.text
end

def main
  a = My_string.new("This is string one")
  b = My_string.new("This is string two")

  puts "a is: " + a.text
  puts "b is: " + b.text

  swap(a, b)

  puts "a is: " + a.text
  puts "b is: " + b.text
end

main
