import socket    # FOR TCP Connection
import sqlite3      # for Database connection
import random    # for generating random registration number

# Create database connection
conn = sqlite3.connect("easydrive.db")
cursor = conn.cursor()

# Create table if it doesn't exist
cursor.execute("""
CREATE TABLE IF NOT EXISTS customers(
    REG_number TEXT PRIMARY KEY,
    NAME TEXT,
    ADDRESS TEXT,
    PPS TEXT,
    LICENSE TEXT
)
""")
conn.commit()

# Create TCP socket
Server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)      #AF_NET for InternetProtocol, SOCK_STREAM for Transmission Control Protocol

# Bind server to port
Server.bind(("127.0.0.1", 5000))                            #Assigns a port number(5000) to the server so that it can listen for incoming connection on that port.

# Start listening
Server.listen(5)                                #The server can have a backlog of 5 connections waiting to be accepted at a time.If more than 5, an error will occur.

print("Server started... Waiting for connection")

while True:

    Client_socket, addr = Server.accept()       #Wait for an incoming connection.
    print("Connection from", addr)

    data = Client_socket.recv(1024).decode()        #Receive data(up to 1024 bytes of data) from the client.

    # Split received data
    NAME, ADDRESS, PPS, LICENSE = data.split("|")

    # Generate registration number
    REG_number = "ED" + str(random.randint(1000,9999))  #Generates a random registration number by joining ED as a prefix with a randomized 4-digit number btw 1000 & 9999.

    # Insert into database
    cursor.execute(
        "INSERT INTO customers VALUES (?,?,?,?,?)",
        (REG_number, NAME, ADDRESS, PPS, LICENSE)           #Stores the received data into the database with the generated Registration Number.
    )
    conn.commit()                                           #saves the changes to the database.

    # Send registration number back to client
    Client_socket.send(REG_number.encode())

    Client_socket.close()                   #Closes the connection with the client after sending the registration number.