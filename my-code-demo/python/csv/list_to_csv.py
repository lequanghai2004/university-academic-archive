import csv

with open("../dataset/iris.csv", "r") as f:
  csv_f = csv.reader(f, delimiter = ",")
  # skip 1 line/row: next(csv_f)
  for row in csv_f:
    sepal_len, sepal_wid, petal_len, petal_wid, name = row
    if len(row) == 5:
      print("{}, {}, {}, {}, - {}".format(sepal_len, sepal_wid, petal_len, petal_wid, name)) 
      
hosts = [("local", "192.168.25.46"),("server", "8.8.8.8")]
with open("list_to.csv", "w", newline = "") as f:
  writer = csv.writer(f)
  writer.writerow(["host", "IP"])
  writer.writerows(hosts)