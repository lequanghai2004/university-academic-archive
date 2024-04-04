import re

re.split(r"[.?!]", "One sentence. Another? And the last!")
# return ['One sentence', 'Another', 'And the last', '']
re.split(r"([.?!])", "One sentence. Another? And the last!")
# return ['One sentence', '.', 'Another', '?', 'And the last', '!', '']

re.sub(r"[\w.%+-]+@[\w.-]+", "[REDACTED]", "Received email for email@example.com")
# Received email for [REDACTED]
re.sub(r"^([\w \.-]*), ([\w \.-]*)$", r"\2 \1", "Lovelace, Ada")
# Ada Lovelace --- result[2] result[1]


def transform_record(record):
  new_record = re.sub(r"^([A-Za-z ]+),([\d-]+),([A-Za-z ]+)$", r"\1,\+1-\2,\3", record)
  return new_record

print(transform_record("Sabrina Green,802-867-5309,System Administrator")) 
# Sabrina Green,+1-802-867-5309,System Administrator

print(transform_record("Eli Jones,684-3481127,IT specialist")) 
# Eli Jones,+1-684-3481127,IT specialist

print(transform_record("Melody Daniels,846-687-7436,Programmer")) 
# Melody Daniels,+1-846-687-7436,Programmer

print(transform_record("Charlie Rivera,698-746-3357,Web Developer")) 
# Charlie Rivera,+1-698-746-3357,Web Developer