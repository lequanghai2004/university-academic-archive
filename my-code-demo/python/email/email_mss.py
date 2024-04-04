from email.message import EmailMessage
import os.path
import mimetypes


mss = EmailMessage()
mss['From'] = "me@gmail"
mss["To"] = "you@gmail"
mss["Subject"] = "Greeting from Ho Chi Minh"

body = """The content goes here ..."""
mss.set_content(body)

attachment = 'images.jpg'
mimetypes, _ = mimetypes.guess_type(attachment)
maintype, subtype = mimetypes.split('/', 1)

with open(attachment, "rb") as f:
  mss.add_attachment(f.read(), maintype=maintype, subtype=subtype,
                     filename=os.path.basename(attachment))

print(mss)
