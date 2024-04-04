import re

result = re.search(r"^(\w*), (\w*)$", "Lovelace, Ada") 
# print(result.groups()) 
# group method returns a TUPLE
# result[0] == "Lovelace, Ada" --> the text match by entire regex
# result[1] == "Lovelace"  
# result[2] == "Ada"

def rearrange_name(name):
  result = re.search(r"^([\w ]*), ([\w \.]*)$", name)
  if result is None:
    return name
  return "{} {}".format(result[2], result[1])

print(rearrange_name("Hopper, Grace M."))