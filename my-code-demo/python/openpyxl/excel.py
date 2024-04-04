import json
import openpyxl

config = None

with open("configure.json", "r", encoding = "utf-8") as f:
    config = json.load(f)

workbook = openpyxl.load_workbook("file.xlsx")
sheet = workbook[config["sheetName"]]

for r in range(config["beginRow"], config["endRow"]+1):
    column = config["column"]
    cell = sheet[f"{column}{r}"]

    for offset in config["offsets"]:
        d_cell = sheet.cell(cell.row, cell.column + offset)
        
        if cell.data_type == "f":
            formula = openpyxl.formula.translate.Translator(cell.value, cell.coordinate)
            d_cell.value = formula.translate_formula(d_cell.coordinate)
        else:
            d_cell.value = cell.value

workbook.save("file1.xlsx")
