class Obj
  attr_accessor :text
  def initialize(text)
    @text = text
  end
end

def change_value_by_reference(obj, text)
  obj.text = text
  # obj is a pointer
  # obj.text is an address
  # however it can also be value
  # depending on the senario
end

def main
  instance = Obj.new("Beginning value")
  puts "At first obj value is: " + instance.text
  change_value_by_reference(instance, "Second value")
  puts "Now, obj value is: " + instance.text
end

main