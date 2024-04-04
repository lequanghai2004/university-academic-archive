import matplotlib.pyplot as plt
import seaborn as sns

# exp 1
# df = sns.load_dataset("penguins")
# sns.jointplot(data=df,x="flipper_length_mm",y="bill_length_mm",hue="species")
# plt.show()

# Apply the default theme
sns.set_theme()
# Load example dataset
tips = sns.load_dataset("tips")
# Create visualization
sns.relplot(data=tips,
    x       = "total_bill", 
    y       = "tip", 
    col     = "time",
    hue     = "smoker", 
    style   = "smoker", 
    size    = "size",
)
plt.show() #show the graph

