from reportlab.platypus import SimpleDocTemplate
from reportlab.platypus import Paragraph, Spacer, Table, Image

from reportlab.lib.styles import getSampleStyleSheet
from reportlab.lib import colors
from reportlab.lib.units import inch

from reportlab.graphics.shapes import Drawing
from reportlab.graphics.charts.piecharts import Pie


tb_style = [('GRID', (0, 0), (-1, -1), 1, colors.black)]
table = [
    ["elderberries", 1],
    ["figs", 1],
    ["apples", 2],
    ["durians", 3],
    ["bananas", 5],
    ["cherries", 8],
    ["grapes", 13]]
rp_table = Table(data=table, style=tb_style, hAlign='LEFT')


rp_pie = Pie(width=15*inch, height=15*inch)
rp_pie.data = []
rp_pie.labels = []

for fruit, amount in sorted(table, key=lambda x: x[1]):
  rp_pie.data.append(amount)
  rp_pie.labels.append(fruit)

rp_chart = Drawing()
rp_chart.add(rp_pie)


report = SimpleDocTemplate("./report.pdf")
styles = getSampleStyleSheet()
rp_title = Paragraph("A Complete Inventory of My Fruit", styles["h1"])

report.build([rp_title, rp_table, rp_chart])
