import csv


with open('../dataset/iris_mod.csv') as dataset:
  reader = csv.DictReader(dataset)
  for row in reader:
    print("name: {} - sapal length: {}".format(row["species"],row["sepal_length"]))
    
keys = ["username", "department"]
user = [{"username": 'Sol', "department": 'IT'},
  {"username": 'Toan', "department": 'marketing'},
  {"username": 'John', "department": 'design'}]

with open("dict_to.csv", "w") as dataset:
  writer = csv.DictWriter(dataset, fieldnames = keys)
  writer.writeheader()
  writer.writerows(user)
  