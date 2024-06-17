import pandas as pd

df = pd.read_csv("../dataset/data_2023.csv", nrows=40, header=0).iloc[:, :10]

df['Annual_Income'] = df['Annual_Income'].str.extract(r"(\d+\.+\d+)")

print(df)
