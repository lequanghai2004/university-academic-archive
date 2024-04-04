import pandas as pd

#read & add header to csv file, file only run when folder 'pandas' is selected
df = pd.read_csv('../dataset/iris.csv')
header_list = ["sepal_length", "sepal_width", "pedal_length", "pedal_width", "species"]
df.to_csv("../dataset/iris_mod.csv", header=header_list, index=False)
df = pd.read_csv('../dataset/iris_mod.csv')

#inplace=True: modification made affect original dataset, default create new (df=df.dropna) 
df.dropna(inplace=True) #drop empty tuples
df["sepal_length"].fillna(130, inplace=True) #fill empty cells with 130 in sepal_length column

mean = df['sepal_length'].mean
