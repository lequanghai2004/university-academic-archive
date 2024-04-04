import smtplib
import getpass

# Establish a secure connection to the mail server
mail_server = smtplib.SMTP_SSL('localhost')
# Enable debugging output
mail_server.set_debuglevel(1)

# Authenticate with the mail server
username = input("Username: ")
password = getpass.getpass("Password: ")
mail_server.login(username, password)

# Send the email
mail_server.sendmail(from_address, to_address, email)

# Close the connection
mail_server.quit()
