import socket       #For TCP connection

print("Client starting...")

def TCP_Client():

    Client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)      #Creates a TCP socket for the client.
    host = '127.0.0.1'
    port = 5000

    Client.connect((host, port))                 #Connects the client to the server at the specified IP address and port number.
    print("Connecting to server...")
    print("Connected!")


    #Prompt user to enter details
    NAME = input("Enter Name: ")
    ADDRESS = input("Enter Address: ")
    PPS = input("Enter PPS Number: ")
    LICENSE = input("Enter Driving License Number: ")

#Combine data into a single string
    data = NAME + "|" + ADDRESS + "|" + PPS + "|" + LICENSE

    print("Sending data...")
    Client.send(data.encode())          #Converts the data string into bytes and sends it to the server.

    print("Waiting for response...")
    REG_number = Client.recv(1024).decode()     #Receives the reg numner from the server and decodees it back to a string.

    print("Your Registration Number:", REG_number)

    Client.close()


#CALL the Function
TCP_Client()