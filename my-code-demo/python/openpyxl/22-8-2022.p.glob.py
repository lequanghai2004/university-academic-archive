import json
import openpyxl

from pathlib import Path
with open("configure.json", "r", encoding = "utf-8") as f:
    config = json.load(f)


p=Path(".")
i=1
for a in p.glob("data/*.xlsx"):
    workbook = openpyxl.load_workbook(a)
    sheet = workbook[config["sheetName"]]

   
   
   
    for r in range(config["beginRow"], config["endRow"]+1): #run within the selected rows
        column = config["column"] #select column
        cell = sheet[f"{column}{r}"] #select cell within the row range

        for offset in config["offsets"]: #column,cell,offset are all variable, offset is now 1 (D1-->D2-->D3-->...)
            d_cell = sheet.cell(cell.row, cell.column + offset) #cell is a function
            
            if cell.data_type == "f": #if the data.type is a formula then copy the whole formula
                formula = openpyxl.formula.translate.Translator(cell.value, cell.coordinate)
                d_cell.value = formula.translate_formula(d_cell.coordinate)
            else: #data is a number, character
                d_cell.value = cell.value
    sa=str(a.name)
    nstr=sa.replace(".xlsx"," (modified).xlsx")
    workbook.save(f"dest/{nstr}")
    i+=1
